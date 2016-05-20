using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RU4.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        //Column mapping is generally not required, because the Entity Framework usually chooses the appropriate SQL Server data type based on the CLR type that you define for the property. The CLR decimal type maps to a SQL Server decimal type. But in this case you know that the column will be holding currency amounts, and the money data type is more appropriate for that.
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Display(Name = "Administrator")]
        //A department may or may not have an administrator, and an administrator is always an instructor. Therefore the InstructorID property is included as the foreign key to the Instructor entity, and a question mark is added after the int type designation to mark the property as nullable.The navigation property is named Administrator but holds an Instructor entity
        public int? InstructorID { get; set; }

        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
