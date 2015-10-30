using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RU.Models
{
    public enum Grade
    {
        A,B,C,D,F
    }
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }

        //The StudentID property is a foreign key, and the corresponding navigation property is Student. An Enrollment entity is associated with one Student entity, so the property can only hold a single Student entity
        public int StudentId { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; } //Foreign Key in this db Table
        public virtual Student Student { get; set; } //Foreign Key in this db Table
    }
}
