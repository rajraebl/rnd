using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

//By convention, the Entity Framework enables cascade delete for non-nullable foreign keys and for many-to-many relationships. 
//This can result in circular cascade delete rules, which will cause an exception when your initializer code runs. 
namespace RU.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        //Earlier you used the Column attribute to change column name mapping only in case of FirstMidName
        //Column attribute is being used to change SQL data type mapping so that the column will be defined using the SQL Server money type in the database:
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }


        [Display(Name = "Administrator")]
        //A department may or may not have an administrator
        public int? InstructorId { get; set; }

        public virtual Instructor Instructor { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
