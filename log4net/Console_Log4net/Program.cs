using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace Console_Log4Net
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = LogManager.GetLogger("MyLogger");
            string c = "";
            log4net.Config.XmlConfigurator.Configure();
            try
            {
                int i = 0;
                var k= 5 / i;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            while(string.IsNullOrEmpty(c))
            {
                logger.Error("something happened");
                c= Console.ReadLine();
            }
        }
    }

    public static class Logger
    {
        private static log4net.ILog Log { get; set; }

        static Logger()
        {
            Log = log4net.LogManager.GetLogger(typeof(Logger));
        }

        public static void Error(object msg)
        {
            Log.Error(msg);
        }

        public static void Error(object msg, Exception ex)
        {
            Log.Error(msg, ex);
        }

        public static void Error(Exception ex)
        {
            Log.Error(ex.Message, ex);
        }

        public static void Info(object msg)
        {
            Log.Info(msg);
        }
    }


}
