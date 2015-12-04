using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.ComponentModel;

namespace RU1.Models
{
    public class Course
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayName("Number")]
        public int CourseId { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0,5)]
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        [Display(Name = "Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Instructor> Instructors { get; set; }

    }
}