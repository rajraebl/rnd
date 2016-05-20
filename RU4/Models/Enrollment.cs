using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RU4.Models
{
    public enum Grade
    {
        A,B,C,D,E,F
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }

        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }

    }
}