using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dinmsp
{
    using System.Configuration;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;

    class Program
    {//http://codethatworks.blogspot.in/2008/11/unity-application-block-21-tutorial.html
        //https://msdn.microsoft.com/en-us/library/ff660914%28v=pandp.20%29.aspx
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            
            //1st way
            //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //section.Containers.Default.Configure(container);

            //2nd way
            //var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            //if (section != null)
            //{
            //    section.Configure(container);
            //}

            //3rd way
            try
            {
                container.LoadConfiguration("ola");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }


            var cc1 = container.Resolve<ICreditCard>();
            cc1.Charge();
            var cc2 = container.Resolve<ICreditCard>();

            var kk = object.ReferenceEquals(cc1, cc2);
            Console.WriteLine("ReferenceEquals: {0}",kk);
            Console.WriteLine("Equals: {0}", object.Equals(cc1,cc2));

            Console.WriteLine("assembly {0}", typeof(Visa).Assembly.FullName);

            Console.WriteLine("------------------------------------------------");

            var nc1 = container.Resolve<ICache>();
            nc1.Save("PollResult");

            Console.Read();
        }


    }

    public interface ICreditCard
    {
        void Charge();
    }

    public class Visa : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging the Visa Card");
        }
    }

    public class Master : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging the Master Card");
        }
    }

    public interface ICache
    {
        void Save(string kk);
    }

    public class NamedCache : ICache
    {
        private IConsoleWriter _cw;
        public NamedCache(IConsoleWriter cw)
        {
            _cw = cw;
        }

        public void Save(string kk)
        {
            _cw.cw("Named Cache Used:" + kk);
        }
    }

    public class MemCache : ICache
    {
        private IConsoleWriter _cw;
        public MemCache(IConsoleWriter cw)
        {
            _cw = cw;
        }

        public void Save(string kk)
        {
            _cw.cw("Memory Cache Used:" + kk);
        }
    }

    public interface IConsoleWriter
    {
        void cw(string s);
    }

    public class ConsoleWriter : IConsoleWriter
    {
        public void cw(string s)
        {
            Console.WriteLine(s);
        }
    }
}
