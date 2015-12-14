using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SapPro.DAL
{
    public interface IPriceRepository
    {
        decimal GetPrice(string productCategory);
    }
}
