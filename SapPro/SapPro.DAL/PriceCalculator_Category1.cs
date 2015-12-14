using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapPro.DAL
{
    public class PriceCalculator_Category1 : PriceCalculator
    {
        public override decimal CalculatePrice()
        {
            return 123.45m;
        }
    }
}
