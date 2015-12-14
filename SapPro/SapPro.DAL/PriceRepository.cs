using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapPro.DAL
{
    public class PriceRepository : IPriceRepository
    {
        public decimal GetPrice(string productCategory)
        {
            decimal price = 0;
            PriceCalculator calc;
            productCategory = productCategory.ToLower();

            if (productCategory == "category 1")
            {
                calc = new PriceCalculator_Category1();
            }
            else if (productCategory == "category 2")
            {
                calc = new PriceCalculator_Category2();
            }
            else if (productCategory == "category 3")
            {
                calc = new PriceCalculator_Category3();
            }
            else
            {
                throw new Exception("Category Not Feeded in system yet.");
            }

            return calc.CalculatePrice();
        }
    }
}
