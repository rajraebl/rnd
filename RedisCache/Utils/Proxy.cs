/*namespace Admiral.Components.ServiceProxy
{
    using System;
    using System.Runtime.Caching;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Threading;
    using Contract;
    using MessageHeader = Contract.MessageHeader;

    /// <summary>
    /// Provides a proxy to WCF services.  This proxy encapsulates
    /// channel creation, caching and fault handling.
    /// </summary>
    /// <typeparam name="TInterface">The interface to the service.</typeparam>
    public class Proxy<TInterface> : IServiceProxy<TInterface>, IDisposable where TInterface : class
    {
        /// <summary>
        /// The FQN of the service contract we are calling, used to disambiguate cache keys when we
        /// have multiple service versions in use.
        /// </summary>
        // ReSharper disable StaticFieldInGenericType
        private static readonly string InterfaceVersionInformation = "::" + typeof(TInterface).Assembly.FullName;
        // ReSharper restore StaticFieldInGenericType

        /// <summary>
        /// Indicates when channels should be created.
        /// </summary>
        private readonly ChannelCreationPolicy _channelCreationPolicy;

        /// <summary>
        /// Provides a factory capable of creating a channel to the service.
        /// </summary>
        private readonly IProxyChannelFactory<TInterface> _channelFactory;

        /// <summary>
        /// Lock used to make the class thread-safe.
        /// </summary>
        private readonly ReaderWriterLockSlim _lock;

        /// <summary>
        /// Cache used for cached service invocations.  In order to preserve the
        /// original implementation of <see cref="Proxy&lt;TInterface&gt;" /> (thereby 
        /// avoiding the need to rework almost every single Unity configuration) 
        /// this can be either injected, or if one of the original caching constructors 
        /// is used, we will create a default memory cache.
        /// </summary>
        /// <remarks>This isn't what we'd do with a clean sheet of paper, but it will
        /// spare a great deal of pain.</remarks>
        private readonly IProxyCache _proxyCache;

        /// <summary>
        /// Number of times a service call should be retried if a TimeoutException or
        /// generic CommunicationException is caught processing it.  A value of 1 means 
        /// that a failed call will be attempted one more time.  Values less than 1 mean
        /// no retries will be attempted.
        /// </summary>
        private readonly int _retryCount;

        /// <summary>
        /// Indicates if the class has been disposed or not.
        /// </summary>
        private bool _disposed;

        /// <summary>
        /// Reference to the service we are invoking.
        /// </summary>
        private readonly ThreadLocal<TInterface> _serviceProxy;

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">Factory that creates channels to the service.</param>
        /// <param name="channelCreationPolicy">Determines when channels should be created.</param>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy)
            : this(channelFactory, channelCreationPolicy, string.Empty, -1, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">Factory that creates channels to the service.</param>
        /// <param name="channelCreationPolicy">Determines when channels should be created.</param>
        /// <param name="retryCount">Number of times a failed call should be retried.</param>
        /// <remarks>A retry value of 1 means 
        /// that a failed call will be attempted one more time.  Values less than 1 mean
        /// no retries will be attempted.
        /// </remarks>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy,
                     int retryCount)
            : this(channelFactory, channelCreationPolicy, string.Empty, retryCount, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">Factory that creates channels to the service.</param>
        /// <param name="channelCreationPolicy">Determines when channels should be created.</param>
        /// <param name="cacheName">Name of the cache to use for cached invocations.</param>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy,
                     string cacheName)
            : this(channelFactory, channelCreationPolicy, cacheName, -1, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">Factory that creates channels to the service.</param>
        /// <param name="channelCreationPolicy">Determines when channels should be created.</param>
        /// <param name="cacheName">Name of the cache to use for cached invocations.</param>
        /// <param name="cacheItemPolicy">Policy to use when added items to a cached invoke.</param>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy,
                     string cacheName,
                     CacheItemPolicy cacheItemPolicy)
            : this(channelFactory, channelCreationPolicy, cacheName, -1, cacheItemPolicy)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">Factory that creates channels to the service.</param>
        /// <param name="channelCreationPolicy">Determines when channels should be created.</param>
        /// <param name="cacheName">Name of the cache to use for cached invocations.</param>
        /// <param name="retryCount">Number of times a service call should be retried before
        /// giving up.</param>
        /// <remarks>A retry value of 1 means 
        /// that a failed call will be attempted one more time.  Values less than 1 mean
        /// no retries will be attempted.
        /// </remarks>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy,
                     string cacheName,
                     int retryCount)
            : this(channelFactory, channelCreationPolicy, cacheName, retryCount, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">The channel factory.</param>
        /// <param name="channelCreationPolicy">The channel creation policy.</param>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="proxyCache">The proxy cache.</param>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy,
                     int retryCount,
                     IProxyCache proxyCache)
            : this(channelFactory, channelCreationPolicy, retryCount)
        {
            if (proxyCache == null) throw new ArgumentNullException("proxyCache");

            _proxyCache = proxyCache;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Proxy&lt;TInterface&gt;"/> class.
        /// </summary>
        /// <param name="channelFactory">Factory that creates channels to the service.</param>
        /// <param name="channelCreationPolicy">Determines when channels should be created.</param>
        /// <param name="cacheName">Name of the cache to use for cached invocations.</param>
        /// <param name="retryCount">Number of times a service call should be retried before
        /// giving up.</param>
        /// <param name="cacheItemPolicy">Policy to use when adding items to the cache.</param>
        /// <remarks>A retry value of 1 means 
        /// that a failed call will be attempted one more time.  Values less than 1 mean
        /// no retries will be attempted. 
        /// </remarks>
        public Proxy(IProxyChannelFactory<TInterface> channelFactory,
                     ChannelCreationPolicy channelCreationPolicy,
                     string cacheName,
                     int retryCount,
                     CacheItemPolicy cacheItemPolicy)
        {
            if (channelFactory == null) throw new ArgumentNullException("channelFactory");

            Timeout = 5000; // Default value - can be overridden via a property.
            _channelFactory = channelFactory;
            _channelCreationPolicy = channelCreationPolicy;
            _retryCount = retryCount;
            _lock = new ReaderWriterLockSlim(LockRecursionPolicy.SupportsRecursion);

            if (!string.IsNullOrWhiteSpace(cacheName))
            {
                if (cacheItemPolicy == null)
                {
                    cacheItemPolicy =
                        new CacheItemPolicy
                        {
                            AbsoluteExpiration =
                                DateTimeOffset.Now.AddMinutes(
                                    Settings.Default.CacheExpiryMins)
                        };
                }

                _proxyCache = new MemoryProxyCache(cacheName, cacheItemPolicy);
            }

            _serviceProxy = new ThreadLocal<TInterface>(() => _channelFactory.CreateChannel());

            if (_channelCreationPolicy == ChannelCreationPolicy.OnProxyCreation)
            {
                // Reference the proxy to force the channel to get created.
#pragma warning disable 168
                var proxy = _serviceProxy.Value;
#pragma warning restore 168
            }
        }

        /// <summary>
        /// Endpoint of the service.
        /// </summary>
        public EndpointAddress EndpointAddress
        {
            get
            {
                return _channelFactory.Endpoint.Address;
            }
        }

        /// <summary>
        /// The timeout in millesconds to apply when we are locking the cache.
        /// </summary>
        /// <remarks>Made a public property so it can be set in Unity without
        /// increasing the number of constructor overloads.</remarks>
        public int Timeout { get; set; }

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, 
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IServiceProxy<TInterface> Members

        /// <summary>
        /// Flushes the cache.
        /// </summary>
        /// <exception cref="ServiceProxyException"> thrown if no
        /// cache is configured in the proxy.</exception>
        public void RemoveCacheEntry()
        {
            if (_proxyCache == null)
            {
                throw new ServiceProxyException("FlushCache called but no cache is configured.");
            }

            _proxyCache.RemoveAll();
        }

        /// <summary>
        /// Flushes a specific entry from the cache.
        /// </summary>
        /// <param name="cacheKey">Key of the item to flush.</param>
        /// <exception cref="ServiceProxyException"> thrown if no
        /// cache is configured in the proxy.</exception>
        public void RemoveCacheEntry(string cacheKey)
        {
            if (_proxyCache == null)
            {
                throw new ServiceProxyException("RemoveCacheEntry called but no cache is configured.");
            }

            _proxyCache.Remove(cacheKey);
        }

        /// <summary>
        /// Adds the cache entry.
        /// </summary>
        /// <param name="cacheKey">The cache key.</param>
        /// <param name="cacheItem">The cache item.</param>
        public void AddCacheEntry(string cacheKey, object cacheItem)
        {
            if (_proxyCache == null)
            {
                throw new ServiceProxyException("AddCacheEntry called but no cache is configured.");
            }

            _proxyCache.AddOrGetExisting(cacheKey, cacheItem);
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// caching, channel creation and fault handling policies.
        /// </summary>
        /// <param name="method">The method to invoke on the service.</param>
        public void Invoke(Action<TInterface> method)
        {
            Invoke(method, _retryCount, null, null);
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// caching, channel creation and fault handling policies.
        /// </summary>
        /// <param name="method">The method to invoke on the service.</param>
        /// <param name="messageHeaders"> </param>
        public void Invoke(Action<TInterface> method, MessageHeader[] messageHeaders)
        {
            Invoke(method, _retryCount, messageHeaders, null);
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// caching, channel creation and fault handling policies.
        /// </summary>
        /// <param name="method">The method to invoke on the service.</param>
        /// <param name="retryCount"> </param>
        public void Invoke(Action<TInterface> method, int retryCount)
        {
            Invoke(method, retryCount, null, null);
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// caching, channel creation and fault handling policies.
        /// </summary>
        /// <param name="method">The method to invoke on the service.</param>
        /// <param name="retryCount">Override of Invoke that allows the retry count to be overridden.</param>
        /// <param name="messageHeaders">The message headers.</param>
        /// <param name="messageProperties">The message properties.</param>
        public void Invoke(Action<TInterface> method, int retryCount, MessageHeader[] messageHeaders, MessageProperties messageProperties)
        {
            int attempts = Math.Max(retryCount + 1, 1);
            while (attempts > 0)
            {
                attempts--;

                try
                {
                    DoInvoke(method, messageHeaders, messageProperties);
                    break; // Everything worked fine so no retries needed.
                }
                catch (FaultException)
                {
                    throw;
                }
                catch (Exception)
                {
                    // Retry if we can, throw if not.
                    if (attempts < 1)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// channel creation and fault handling policies.
        /// </summary>
        /// <typeparam name="TOut">The return type of the service call.</typeparam>
        /// <param name="method">The method to invoke on the service.</param>
        /// <returns>Result of the service invocation.</returns>
        public TOut Invoke<TOut>(Func<TInterface, TOut> method)
        {
            return Invoke(method, _retryCount, null, null);
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// channel creation and fault handling policies.
        /// </summary>
        /// <typeparam name="TOut">The return type of the service call.</typeparam>
        /// <param name="method">The method to invoke on the service.</param>
        /// <param name="messageHeaders"> </param>
        /// <returns>Result of the service invocation.</returns>
        public TOut Invoke<TOut>(Func<TInterface, TOut> method, MessageHeader[] messageHeaders)
        {
            return Invoke(method, _retryCount, messageHeaders, null);
        }

        /// <summary>
        /// Invokes the specified method on the service.
        /// </summary>
        /// <typeparam name="TOut">The type of the method return value.</typeparam>
        /// <param name="method">A lambda to invoke.</param>
        /// <param name="retryCount">Override of Invoke that allows the retry count to be overridden.</param>

        /// <returns>Result of calling the method.</returns>
        public TOut Invoke<TOut>(Func<TInterface, TOut> method, int retryCount)
        {
            return Invoke(method, retryCount, null, null);
        }


        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="messageProperties">The message properties.</param>
        public void Invoke(Action<TInterface> method, MessageProperties messageProperties)
        {
            Invoke(method, _retryCount, null, messageProperties);
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="messageProperties">The message properties.</param>
        public void Invoke(Action<TInterface> method, int retryCount, MessageProperties messageProperties)
        {
            Invoke(method, retryCount, null, messageProperties);
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="messageProperties">The message properties.</param>
        /// <returns></returns>
        public TOut Invoke<TOut>(Func<TInterface, TOut> method, MessageProperties messageProperties)
        {
            return Invoke(method, _retryCount, null, messageProperties);
        }

        /// <summary>
        /// Invokes the specified method.
        /// </summary>
        /// <typeparam name="TOut">The type of the out.</typeparam>
        /// <param name="method">The method.</param>
        /// <param name="retryCount">The retry count.</param>
        /// <param name="messageProperties">The message properties.</param>
        /// <returns></returns>
        public TOut Invoke<TOut>(Func<TInterface, TOut> method, int retryCount, MessageProperties messageProperties)
        {
            return Invoke(method, retryCount, null, messageProperties);
        }


        public TOut Invoke<TOut>(Func<TInterface, TOut> method, int retryCount, MessageHeader[] messageHeaders)
        {
            return Invoke(method, retryCount, messageHeaders, null);
        }

        public void Invoke(Action<TInterface> method, int retryCount, MessageHeader[] messageHeaders)
        {
            Invoke(method, retryCount, messageHeaders, null);
        }

        public TOut Invoke<TOut>(Func<TInterface, TOut> method, MessageHeader[] messageHeaders, MessageProperties messageProperties)
        {
            return Invoke(method, _retryCount, messageHeaders, messageProperties);
        }

        /// <summary>
        /// Invokes the specified method on the service.
        /// </summary>
        /// <typeparam name="TOut">The type of the method return value.</typeparam>
        /// <param name="method">A lambda to invoke.</param>
        /// <param name="retryCount">Override of Invoke that allows the retry count to be overridden.</param>
        /// <param name="messageHeaders">The message headers.</param>
        /// <param name="messageProperties">The message properties.</param>
        /// <returns>
        /// Result of calling the method.
        /// </returns>
        public TOut Invoke<TOut>(Func<TInterface, TOut> method, int retryCount, MessageHeader[] messageHeaders, MessageProperties messageProperties)
        {
            int attempts = Math.Max(retryCount + 1, 1);
            while (attempts > 0)
            {
                attempts--;

                try
                {
                    return DoInvoke(method, messageHeaders, messageProperties);
                }
                catch (Exception)
                {
                    // Retry if we can, throw if not.
                    if (attempts < 1)
                    {
                        throw;
                    }
                }
            }

            // We should never reach this line, because if we have run out of attempts
            // we should have returned successfully or rethrown the appropriate
            // exception.
            throw new ServiceProxyException(
                "Exhausted retries but exception not re-thrown.  Check logic in Proxy class.");
        }

        /// <summary>
        /// Does a cached invocation of the specified method on the service.  If
        /// a result is found in cache, that will be returned; otherwise the
        /// service will be called and the result cached.
        /// </summary>
        /// <typeparam name="TOut">The type of the method return value.</typeparam>
        /// <param name="method">A lambda to invoke.</param>
        /// <param name="cacheKey">The key to use to store the result in the cache.</param>
        /// <returns>Result of calling the method.</returns>
        public TOut CachedInvoke<TOut>(Func<TInterface, TOut> method, string cacheKey)
        {
            var acquiredLock = false;
            try
            {
                acquiredLock = _lock.TryEnterReadLock(Timeout);
                if (!acquiredLock)
                {
                    throw new ServiceProxyException(string.Format("Failed to obtain read lock to call {0} after {1}ms",
                                                                  method.Method.Name,
                                                                  Timeout));
                }

                if (_proxyCache == null)
                {
                    throw new ServiceProxyException("CachedInvoke called but no cache is configured.");
                }

                if (_proxyCache.Contains(cacheKey))
                {
                    return (TOut)_proxyCache[cacheKey];
                }
            }
            finally
            {
                if (acquiredLock)
                {
                    _lock.ExitReadLock();
                }
            }

            acquiredLock = false;
            try
            {
                // We are not using upgradeable locks because we want concurrent read threads to
                // be permitted.  This means we have to relinquish the read lock and then apply
                // for a write lock.
                acquiredLock = _lock.TryEnterWriteLock(Timeout);
                if (!acquiredLock)
                {
                    throw new ServiceProxyException(string.Format("Failed to obtain write lock to call {0} after {1}ms",
                                                                  method.Method.Name,
                                                                  Timeout));
                }

                var result = Invoke(method);

                // ReSharper disable CompareNonConstrainedGenericWithNull
                // Checking against value type presents value types being compared against null.
                if ((typeof(TOut).IsValueType) || (result != null))
                // ReSharper restore CompareNonConstrainedGenericWithNull
                {
                    _proxyCache.AddOrGetExisting(cacheKey, result);
                }

                return result;
            }
            finally
            {
                if (acquiredLock)
                {
                    _lock.ExitWriteLock();
                }
            }
        }

        /// <summary>
        /// Does a cached invocation of the specified method on the service.  
        /// Uses the version of the assembly to ensure type safety, bu appending to the key.
        /// If a result is found in cache, that will be returned; otherwise the
        /// service will be called and the result cached.
        /// </summary>
        /// <typeparam name="TOut">The type of the method return value.</typeparam>
        /// <param name="method">A lambda to invoke.</param>
        /// <param name="cacheKey">The key to use to store the result in the cache.</param>
        /// <returns>Result of calling the method.</returns>
        public TOut VersionedCachedInvoke<TOut>(Func<TInterface, TOut> method, string cacheKey)
        {
            // Append the version information
            return CachedInvoke(method, string.Concat(cacheKey, InterfaceVersionInformation));
        }



        #endregion

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// Proxy is reclaimed by garbage collection.
        /// </summary>
        /// <remarks>Normally we would expect our Dispose method to be called, but our
        /// user may not do so.</remarks>
        ~Proxy()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; 
        /// <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_channelFactory.State == CommunicationState.Opened)
                    {
                        _channelFactory.Close();
                    }

                    if ((_serviceProxy != null) && (_serviceProxy.IsValueCreated))
                    {
                        _serviceProxy.Dispose();
                    }

                    _lock.Dispose();
                }
            }

            _disposed = true;
        }

        /// <summary>
        /// Invokes the specified method on the service, applying all relevant
        /// caching, channel creation and fault handling policies.
        /// </summary>
        /// <param name="method">The method to invoke on the service.</param>
        /// <param name="messageHeaders">The message headers.</param>
        /// <param name="messageProperties">The message properties.</param>
        private void DoInvoke(Action<TInterface> method, MessageHeader[] messageHeaders, MessageProperties messageProperties)
        {
            CreateChannelIfNeeded();
            try
            {

                if ((messageHeaders == null || messageHeaders.Length == 0) && (messageProperties == null || messageProperties.Count == 0))
                {

                    method(_serviceProxy.Value);
                }
                else
                {
                    var channel = _serviceProxy.Value as IClientChannel;
                    if (channel == null)
                        throw new NullReferenceException("_serviceProxy.Value must be of type IClientChannel");

                    // ReSharper disable UnusedVariable
                    //Setting a message header needs to take place in an operation scope even through it is not used directly.
                    using (var operatingScope = new OperationContextScope(channel))
                    // ReSharper restore UnusedVariable
                    {
                        //Add message headers
                        if ((messageHeaders != null && messageHeaders.Length > 0))
                            foreach (var header in messageHeaders)
                            {
                                var wcfHeader = new MessageHeader<string>(header.Value);
                                var wcfHeaderBase = wcfHeader.GetUntypedHeader(header.Name, header.Namespace);
                                OperationContext.Current.OutgoingMessageHeaders.Add(wcfHeaderBase);

                            }

                        //Add message properties
                        if (messageProperties != null && messageProperties.Count > 0)
                            foreach (var messageProperty in messageProperties)
                            {
                                OperationContext.Current.OutgoingMessageProperties.Add(messageProperty.Key,
                                                                                    messageProperty.Value);
                            }
                        method(_serviceProxy.Value);
                    }
                }



            }
            finally
            {
                TeardownChannelIfNeeded();
            }
        }


        /// <summary>
        /// Invokes the specified method on the service.
        /// </summary>
        /// <typeparam name="TOut">The return type of the service call.</typeparam>
        /// <param name="method">The method to invoke on the service.</param>
        /// <param name="messageHeaders">The message headers.</param>
        /// <param name="messageProperties">The message properties.</param>
        /// <returns>
        /// Result of the service invocation.
        /// </returns>
        private TOut DoInvoke<TOut>(Func<TInterface, TOut> method, MessageHeader[] messageHeaders, MessageProperties messageProperties)
        {
            CreateChannelIfNeeded();
            try
            {
                if ((messageHeaders == null || messageHeaders.Length == 0) && (messageProperties == null || messageProperties.Count == 0))
                {
                    return method.Invoke(_serviceProxy.Value);
                }
                else
                {
                    var channel = _serviceProxy.Value as IClientChannel;
                    if (channel == null)
                        throw new NullReferenceException("_serviceProxy.Value must be of type IClientChannel");

                    // ReSharper disable UnusedVariable
                    //Setting a message header needs to take place in an operation scope even through it is not used directly.
                    using (var operatingScope = new OperationContextScope(channel))
                    // ReSharper restore UnusedVariable
                    {
                        //Add message headers
                        if ((messageHeaders != null && messageHeaders.Length > 0))
                            foreach (var header in messageHeaders)
                            {
                                var wcfHeader = new MessageHeader<string>(header.Value);
                                var wcfHeaderBase = wcfHeader.GetUntypedHeader(header.Name, header.Namespace);
                                OperationContext.Current.OutgoingMessageHeaders.Add(wcfHeaderBase);
                            }

                        //Add message properties
                        if (messageProperties != null && messageProperties.Count > 0)
                            foreach (var messageProperty in messageProperties)
                            {
                                OperationContext.Current.OutgoingMessageProperties.Add(messageProperty.Key,
                                                                                    messageProperty.Value);
                            }

                        return method.Invoke(_serviceProxy.Value);
                    }
                }

            }
            finally
            {
                TeardownChannelIfNeeded();
            }
        }


        /// <summary>
        /// Creates the channel if necessary.
        /// </summary>
        private void CreateChannelIfNeeded()
        {
            // Creates channel if it has previously been disposed.
            if (_serviceProxy.Value == null)
            {
                _serviceProxy.Value = _channelFactory.CreateChannel();
                return;
            }

            // Recreate channel if it has faulted.
            var serviceProxy = _serviceProxy.Value as ICommunicationObject;
            if (serviceProxy == null)
            {
                // Defensive code - should never happen
                throw new InvalidOperationException(
                    "Proxy failed to cast channel to an ICommunicationException: component is misconfigured");
            }

            if (serviceProxy.State == CommunicationState.Faulted)
            {
                _serviceProxy.Value = _channelFactory.CreateChannel();
            }
        }

        /// <summary>
        /// Tears down the channel if it is not needed after the call.
        /// </summary>
        private void TeardownChannelIfNeeded()
        {
            if (_channelCreationPolicy == ChannelCreationPolicy.OncePerCall)
            {
                var serviceProxy = _serviceProxy.Value as ICommunicationObject;

                if (serviceProxy != null)
                {
                    try
                    {
                        if (serviceProxy.State != CommunicationState.Faulted)
                        {
                            serviceProxy.Close();
                        }
                        else
                        {
                            serviceProxy.Abort();
                        }
                    }
                    finally
                    {
                        _serviceProxy.Value = null;
                    }
                }
            }
        }
    }

}*/