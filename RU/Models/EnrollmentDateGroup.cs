using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RU.Models
{
    /*
     For : this prop in calss
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }

the out will be

                @item.EnrollmentDate    //11-08-2005 AM 12:00:00
                @Html.DisplayFor(x => item.EnrollmentDate)   //11-08-2005


     */
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        public int StudentCount { get; set; }
    }
}