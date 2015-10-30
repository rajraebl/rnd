using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        //Navigation properties are typically defined as virtual so that they can take advantage of certain Entity Framework functionality such as lazy loading.
        public virtual ICollection<Enrollment> Enrollments { get; set; } //The Enrollments property is a navigation property
    }
}