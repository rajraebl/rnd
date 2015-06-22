using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CustomControllerFactory.Services
{
    public interface ILoggerService
    {
        void Log(string s);
    }
    public class LoggerService : ILoggerService
    {
        public void Log(string s)
        {
            HttpContext.Current.Response.Write("Message from Logger Service is:" + s);
        }
    }
}