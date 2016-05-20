using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RU4.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name="Number")]
        public int CourseId { get; set; }

        [StringLength(30, MinimumLength=1)]
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        [Display(Name="Department")]
        public int DepartmentId { get; set; }


        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }


    }
}