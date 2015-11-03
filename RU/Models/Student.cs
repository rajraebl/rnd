using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RU.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        //If a given Student row in the database has two related Enrollment rows (rows that contain that student's primary key value in their StudentID foreign key column), 
        //that Student entity's Enrollments navigation property will contain those two Enrollment entities.
        //Navigation properties are typically defined as virtual so that they can take advantage of certain Entity Framework functionality such as lazy loading.
        //If a navigation property can hold multiple entities (as in many-to-many or one-to-many relationships), 
        //its type must be a list in which entries can be added, deleted, and updated, such as ICollection.
        public virtual ICollection<Enrollment> Enrollments { get; set; } 
    }
}