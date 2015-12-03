using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace RU1.Models
{
    public class OfficeAssignment
    {

        /*When there is a  one-to-zero-or-one relationship or a  one-to-one relationship between two entities (such as between OfficeAssignment and Instructor), EF can't work out which end of the relationship is the principal and which end is dependent.  One-to-one relationships have a reference navigation property in each class to the other class. The ForeignKey Attribute can be applied to the dependent class to establish the relationship. */
        [Display(Name = "Office Locaton"), StringLength(12)]
        public string Location { get; set; }

        [Key, ForeignKey("Instructor")]
        public int InstructorId { get; set; }
        public virtual Instructor Instructor { get; set; }
    }
}
