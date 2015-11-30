using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ticket.Models
{
    public class Company
    {
        public List<Department> Departments { get; set; }
    }

    public class Department {
        public string DepartmentName  { get; set; }
        public string AdminName { get; set; }
    }
}