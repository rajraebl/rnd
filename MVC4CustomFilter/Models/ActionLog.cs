using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVC4CustomFilter.Models
{
    public class ActionLog
    {
        public string controller { get; set; }
        public string action { get; set; }
        public string ip { get; set; }
        public string timestamp { get; set; }
    }
}
