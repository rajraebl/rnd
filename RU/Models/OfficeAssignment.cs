using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RU.Models
{
    //http://www.asp.net/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/creating-a-more-complex-data-model-for-an-asp-net-mvc-application
    public class OfficeAssignment
    {
        //InstructorID is the key for this table to identify a unique row + it is also a forein key coming from Instructor table
        // Entity Framework can't automatically recognize InstructorID as the primary key 
        [Key]

        //When there is a  one-to-zero-or-one relationship or a  one-to-one relationship between two entities (such as between OfficeAssignment and Instructor), 
        //EF can't work out which end of the relationship is the principal and which end is dependent.  
        //One-to-one relationships have a reference navigation property in each class to the other class. 
        //The ForeignKey Attribute can be applied to the dependent class to establish the relationship
        [ForeignKey("Instructor")]
        public int InstructorId { get; set; }

        [StringLength(50), Display(Name = "Office Location")]
        public string Location { get; set; }

        public virtual Instructor Instructor { get; set; }
    }
}
