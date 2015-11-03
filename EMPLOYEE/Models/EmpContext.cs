using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace EMPLOYEE.Models
{
    public class EmpContext : DbContext
    {
        public DbSet<Employee> tblEmp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //tblEmp.Add(new Employee() { Name = "Rajesh", Mobile = "9654", Email = "r@j.com" });
            //tblEmp.Add(new Employee() { Name = "Rajes", Mobile = "965", Email = "r@j.com" });
            //tblEmp.Add(new Employee() { Name = "Raje", Mobile = "954", Email = "r@j.com" });
            //tblEmp.Add(new Employee() { Name = "Raj", Mobile = "964", Email = "r@j.com" });
        }
        
        
    }
}