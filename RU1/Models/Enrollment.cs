using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RU1.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }

        public Grade? Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }

    public enum Grade
    {
        A,B,C,D,E
    }
}
