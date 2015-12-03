using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        [Required, StringLength(12), Display(Name = "Last Name")]
        public string  LastName { get; set; }

        [StringLength(12), Column("FirstName"), DisplayName("Firat Name")]
        public string FirstMidName { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true), DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }


        //it has only a get accessor, and no FullName column will be generated in the database.
        public string FullName { get { return LastName + ", " + FirstMidName; } }

        // if a navigation property can hold multiple entities, its type must implement the ICollection<T> Interface. 
        //(For example IList<T> qualifies but not IEnumerable<T> because IEnumerable<T> doesn't implement Add.
        public virtual ICollection<Course> Courses { get; set; }

        //Our business rules state an instructor can only have at most one office, so OfficeAssignment is defined as a single OfficeAssignment entity (which may be null if no office is assigned).
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }

    }
