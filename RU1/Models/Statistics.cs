using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RU1.Models
{
    public class Statistics
    {
        [DataType(DataType.Date)]
        public DateTime EnrollmentDate { get; set; }
        public int Count { get; set; }
    }
}