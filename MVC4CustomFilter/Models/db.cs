using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC4CustomFilter.Models
{
    public class db
    {
        public static List<Emp> Emps = new List<Emp>() { 
            new Emp { id = 1, country = "ind", name = "raje" } 
        ,new Emp { id = 2, country = "indo", name = "rake" } 
        };

        public static List<ActionLog> ActionLogs = new List<ActionLog>() {        };
    }
}