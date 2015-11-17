using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RU.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        //The StringLength attribute won't prevent a user from entering white space for a name. You can use the RegularExpression attribute to apply restrictions to the input.
        //The MaxLength attribute provides similar functionality to the StringLength attribute but doesn't provide client side validation.
        [StringLength(50, MinimumLength = 1)]
        public string LastName { get; set; }

        //Some attributes such as MinimumLength can't be applied with the fluent API.
        [StringLength(50, MinimumLength = 1, ErrorMessage = "FirstName can not be longer than 50 chars")]
        public string FirstName { get; set; }

        //The DataType attributes emits HTML 5 data- (pronounced data dash) attributes that HTML 5 browsers can understand. The DataType attributes do not provide any validation. 
        //DataType.Date does not specify the format of the date that is displayed. By default, the data field is displayed according to the default formats based on the server's CultureInfo.
        //With this The browser can enable HTML5 features like date calender, currency symbol, email link
        [DataType(DataType.Date)]

        //The DisplayFormat attribute is used to explicitly specify the date format:
        //The ApplyFormatInEditMode setting specifies that the specified formatting should also be applied when the value is displayed in a text box for editing. 
        //(You might not want that for some fields — for example, for currency values, you might not want the currency symbol in the text box for editing.)
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]

        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        public string FullName
        {
            get { return LastName + ", " + FirstName; }
        }

        //If a given Student row in the database has two related Enrollment rows (rows that contain that student's primary key value in their StudentID foreign key column), 
        //that Student entity's Enrollments navigation property will contain those two Enrollment entities.
        //Navigation properties are typically defined as virtual so that they can take advantage of certain Entity Framework functionality such as lazy loading.
        //If a navigation property can hold multiple entities (as in many-to-many or one-to-many relationships), 
        //its type must be a list in which entries can be added, deleted, and updated, such as ICollection.
        public virtual ICollection<Enrollment> Enrollments { get; set; } 
    }
}