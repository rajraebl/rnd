using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathLib
{
    public interface IMathClass
    {
        int add();
        int subs();

         int GetTheCurrentYear();

    }

    public class MathClass : IMathClass
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }

        public MathClass(int num1, int num2)
        {
            Number1 = num1;
            Number2 = num2;
        }

        public int add()
        { return Number1 + Number2; }

        public int subs()
        { return Number1 - Number2; }

        public int GetTheCurrentYear()
        {
            return DateTime.Now.Year;
        }
    }
}
