using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace RU4.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        //The MaxLength attribute provides similar functionality to the StringLength attribute but doesn't provide client side validation.
        [StringLength(10,ErrorMessage="cant be greater thean 10 chars")]
        //when your code refers to Student.FirstMidName, the data will come from or be updated in the FirstName column of the Student table. If you don't specify column names, they are given the same name as the property name.
        [Column("FirstName")]
        public string FirstMidName { get; set; }
        /*The DataType attribute is used to specify a data type that is more specific than the database intrinsic type. In this case we only want to keep track of the date, not the date and time. The  DataType Enumeration provides for many data types, such as Date, Time, PhoneNumber, Currency, EmailAddress and more. 
         * The DataType attributes emits HTML 5 data- (pronounced data dash) attributes that HTML 5 browsers can understand. The DataType attributes do not provide any validation. 
         * The DisplayFormat attribute is used to explicitly specify the date format:
         * The ApplyFormatInEditMode setting specifies that the specified formatting should also be applied when the value is displayed in a text box for editing. (You might not want that for some fields — for example, for currency values, you might not want the currency symbol in the text box for editing.)
         */
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}