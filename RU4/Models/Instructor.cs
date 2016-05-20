using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RU4.Models
{
    public class Instructor
    {
        public int InstructorID { get; set; }

        [Display(Name="Last Name")]
        [Required]
        [StringLength(15)]
        public string LastName { get; set; }

        [Required]
        [Display(Name="First Name")]
        [StringLength(20, ErrorMessage="cant b more than 20 chars length")]
        [Column("FirstName")]

        public string FirstMidName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime HireDate { get; set; }

        //FullName is a calculated property that returns a value that's created by concatenating two other properties. Therefore it has only a get accessor, and no FullName column will be generated in the database.
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        //if a navigation property can hold multiple entities, its type must implement the ICollection<T> Interface. (For example IList<T> qualifies but not IEnumerable<T> because IEnumerable<T> doesn't implement Add.
        public virtual ICollection<Course> Courses { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }



    }
}