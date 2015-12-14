using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapPro.DAL
{
    public abstract class PriceCalculator
    {
        public abstract decimal CalculatePrice();
    }
}
