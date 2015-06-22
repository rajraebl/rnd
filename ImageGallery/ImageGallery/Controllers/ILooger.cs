using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageGallery.Controllers
{
   public  interface ILogger
   { }
    public class Logger : ILogger
    {
        public Logger(int x)
        { }
    }
}
