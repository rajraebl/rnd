using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSPA.Data
{
    public class TrainingProduct
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public DateTime IntroductionDate { get; set; }
        public string Url { get; set; }
        public decimal Price { get; set; }
    }
}