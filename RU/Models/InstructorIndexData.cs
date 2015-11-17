using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU.Models
{
    //The Instructor Index page shows three different tables.
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}