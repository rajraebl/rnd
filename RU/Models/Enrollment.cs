using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
       // The CourseID property is a foreign key, and the corresponding navigation property is Course
        public int CourseID { get; set; } // will become foreign key of this table
        public int StudentID { get; set; }

        //The question mark after the Grade type declaration indicates that the Grade property is nullable. 
        //A grade that's null is different from a zero grade — null means a grade isn't known or hasn't been assigned yet.
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

    public enum Grade
    {
        A,B,C,D,F
    }
}