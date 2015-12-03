using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        //The MaxLength attribute provides similar functionality to the StringLength attribute but doesn't provide client side validation.
        [StringLength(10,MinimumLength = 1, ErrorMessage = "{0} can not be less than {2} long and can not be longer than {1}")]
        public string LastName { get; set; }

        [Column("FirstName"), StringLength(10)]
        public string FirstMidName { get; set; }

        public string FullName { get { return LastName + ", " + FirstMidName; } }

        //The DataType attribute is used to specify a data type that is more specific than the database intrinsic type. 
        //In this case we only want to keep track of the date, not the date and time.
        //DataType.Date does not specify the format of the date that is displayed. 
        //By default, the data field is displayed according to the default formats based on the server's CultureInfo.
        [DataType(DataType.Date ), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}