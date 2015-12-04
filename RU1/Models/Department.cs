using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        [DataType(DataType.Currency), Column(TypeName = "money")]
        public Decimal Budget { get; set; }

        public DateTime StartDate { get; set; }

        [Display(Name = "Administrator")]
        public int?  InstructorId { get; set; }

        public virtual Instructor Administrator { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}