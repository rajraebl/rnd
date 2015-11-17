using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RU.Models
{
    //http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
    public class Instructor
    {
        public int InstructorId{ get; set; }

        //The StringLength attribute sets the maximum length  in the database and provides client side and server side validation for ASP.NET MVC. 
        //You can also specify the minimum string length in this attribute, but the minimum value has no impact on the database schema. 
        [Required, StringLength(50, MinimumLength = 1), Display(Name = "Last Name")]
        public string LastName { get; set; }

        //The Column attribute specifies that when the database is created, the column of the Student table that maps to the FirstMidName property will be named FirstName. 
        //In other words, when your code refers to Student.FirstMidName, the data will come from or be updated in the FirstName column of the Student table. 
        //If you don't specify column names, they are given the same name as the property name.
        [Required, StringLength(50), DisplayName("First Name"), Column("FirstName")]
        public string FirstMidName { get; set; }

        //The Required attribute is not needed for value types such as DateTime, int, double, and float. Value types cannot be assigned a null value, so they are inherently required.
        [DataType(DataType.Date), Display(Name = "Hire Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }


        // it has only a get accessor, therefor no FullName column will be generated in the database.
        public string FullName
        {
            get { return LastName + ", " + FirstMidName; }
        }

        //defined as virtual so that they can take advantage of an Entity Framework feature called lazy loading.
        //An instructor can teach any number of courses, so Courses is defined as a collection of Course entities. 
        public virtual ICollection<Course> Corses { get; set; }

        //Our business rules state an instructor can only have at most one office, so OfficeAssignment is defined as a single OfficeAssignment entity (which may be null if no office is assigned).
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}