using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Compare.Utilities.Azure.RedisCache.Common;
using StackExchange.Redis;

namespace Compare.Utilities.Azure.RedisCache
{
    internal class Program
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            var connString = ConfigurationManager.ConnectionStrings["RedisCache"].ToString();
            return ConnectionMultiplexer.Connect(connString);
        });

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }

        private static readonly string[] CommandSwitches = new string[] { "-CLEANALLCACHE", "-CLEANNAMEDCACHE", "-CLEANREGION", "-HELP" };

        private static void Main(string[] args)
        {
            //CleanRegion("PARTNERDATACACHE", "raje");

            var commandOperation = ValidateArguments(args);


            if (commandOperation != CommandOperation.None && commandOperation != CommandOperation.Error)
            {
                //WriteError(commandOperation.ToString());

                switch (commandOperation)
                {
                    case CommandOperation.CleanNamedCache:
                        CleanCache(args[1]);
                        break;
                    case CommandOperation.CleanFullCache:
                        CleanCache();
                        break;
                    case CommandOperation.CleanRegion:
                        CleanRegion(args[1], args[2]);
                        break;
                    case CommandOperation.Help:
                        ShowCommandHelp();
                        break;
                }
            }
        }

        private static void CleanRegion(string cacheName, string regionName)
        {
            try
            {
            int dbId = (int)Enum.Parse(typeof(Common.CacheName), cacheName.ToUpper());
            IDatabase cache = Connection.GetDatabase(dbId);
            var endpoints = Connection.GetEndPoints();
            var server = Connection.GetServer(endpoints.First());

            var keys = server.Keys(dbId, pattern: regionName + "_*");
                if (keys.LongCount() > 0)
                {
                    WriteMessage("Keys deleted in region are:");
                    foreach (var key in keys)
                    {
                        //var c = cache.KeyExists(key.ToString());

                        cache.KeyDelete(key);
                        WriteMessage(key.ToString());
                    }
                }
                else
                {
                    WriteMessage("No keys found in the region");
                }
            }

                        catch (Exception ex)
                        {
                            WriteError("Command Un-Successful");
                            WriteError(ex.Message);
                        }

        }

        private static void CleanCache(string cacheName = "ALL")
        {
            try
            {
                var endpoints = Connection.GetEndPoints();
                var server = Connection.GetServer(endpoints.First());
                if (cacheName == "ALL")
                {
                    server.FlushAllDatabases();
                    WriteMessage("All Cache Cleaned Successfuly.");

                }
                else if (cacheName != "")
                {
                    int dbId = (int) Enum.Parse(typeof (Common.CacheName), cacheName.ToUpper());

                    server.FlushDatabase(dbId);
                    WriteMessage(string.Format("Cache \"{0}\" Cleaned Successfuly.", cacheName));
                }
            }
            catch (Exception ex)
            {
                WriteError("Command Un-Successful");
                WriteError(ex.Message);
            }
        }

        private static CommandOperation ValidateArguments(IList<string> commandArguments)
        {
            var commandOperation = CommandOperation.None;

            if (commandArguments != null && commandArguments.Count > 0)
            {
                var commandSwitch = commandArguments[0].ToUpper();

                if (CommandSwitches.Contains(commandSwitch))
                {
                    if (commandSwitch == CommandSwitches[0])
                    {
                            commandOperation = CommandOperation.CleanFullCache;
                    }
                    else if (commandSwitch == CommandSwitches[1])
                    {
                        if (commandArguments.LongCount() > 1)
                        {
                            commandOperation = CommandOperation.CleanNamedCache;
                        }
                        else
                        {
                            commandOperation = CommandOperation.Error;
                            WriteError("Missing Required Argument(s) CacheName.");
                        }
                    }
                    else if (commandSwitch == CommandSwitches[2])
                    {
                        if (commandArguments.LongCount() > 2)
                        {
                            commandOperation = CommandOperation.CleanRegion;
                        }
                        else
                        {
                            commandOperation = CommandOperation.Error;
                            WriteError("Missing Required Argument(s) CacheName and/or Region Name.");
                        }
                    }

                    else if (commandSwitch == CommandSwitches[3])
                    {
                        commandOperation = CommandOperation.Help;
                    }
                }
                else
                {
                    commandOperation = CommandOperation.Error;
                    WriteError(string.Format("Invalid Command Switch : {0}", commandArguments[0]));
                }
            }
            else
            {
                commandOperation = CommandOperation.Error;
                WriteError("Missing Required Argument(s)");
                ShowCommandHelp();
            }

            return commandOperation;
        }

        /// <summary>
        /// Displays help content about command.
        /// </summary>
        private static void ShowCommandHelp()
        {
            Console.WriteLine();
            Console.WriteLine("============================ CleanRedisCache Commands ====================================================");
            Console.WriteLine("Cleans All Data From Named Cache OR Region Inside a Named Cache on Azure Redis Cache.");
            Console.WriteLine("Make Sure Redis Cache Credentials Present In Config file Are All Correct.");
            Console.WriteLine();
            Console.WriteLine("Usage Example : ");
            Console.WriteLine();
            Console.WriteLine("Get Help On Command                              : CleanRedisCache -Help");
            Console.WriteLine("Clean All the Named Cache                        : CleanRedisCache -CleanAllCache");
            Console.WriteLine("Clean A Given Named Cache                        : CleanRedisCache -CleanNamedCache <CacheName>");
            Console.WriteLine("Clean A Given Region Inside A Given Named Cache  : CleanRedisCache -CleanRegion <CacheName> <RegionName>");
            Console.WriteLine();

            Console.WriteLine("=========================================================================================================");
        }

        /// <summary>
        /// Formats & displays error messages.
        /// </summary>
        /// <param name="errorMessage">Error Message</param>
        private static void WriteError(string errorMessage)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        /// <summary>
        /// Formats & displays messages.
        /// </summary>
        /// <param name="message"></param>
        private static void WriteMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(message);
            Console.ResetColor();
        }

    }
}
