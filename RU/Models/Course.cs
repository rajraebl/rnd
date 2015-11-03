using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RU.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)] // lets you enter the primary key for the course rather than having the database generate it.
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }

    }
}