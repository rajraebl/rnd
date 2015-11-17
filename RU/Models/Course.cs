using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RU.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // lets you enter the primary key for the course rather than having the database generate it.
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        //The Entity Framework doesn't require you to add a foreign key property to your data model when you have a navigation property for a related entity.  
        //EF automatically creates foreign keys in the database wherever they are needed. But having the foreign key in the data model can make updates simpler and more efficient. 
        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
        public virtual Department Department { get; set; } 

    }
}