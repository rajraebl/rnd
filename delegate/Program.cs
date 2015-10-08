using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @delegate
{
    public delegate int BizRuleDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {

            /*
            //these are 2 business rules which can b passed dynamically to the process data */
            BizRuleDelegate addDel = (x, y) => x + y;
            BizRuleDelegate mulDel = (x, y) => x * y;

            ProcessDta pd = new ProcessDta();
            pd.ProcessViaDelegate(3, 5, addDel);
            pd.ProcessViaDelegate(3, 5, mulDel);
            

            /* these r 2 business logic which are passed dyncamically but do not return anything*/
            Action<int, int> addAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> mulAction = (x, y) => Console.WriteLine(x*y);
            ProcessDta pd1 = new ProcessDta();
            pd1.ProcessViaAction(3, 5, addAction);
            pd1.ProcessViaAction(3,5,mulAction);

            /* these r 2 business logic which are passed dyncamically but do not return anything*/
            Func<int, int, int> addFunc = (x, y) => x + y;
            Func<int, int, int> mulFunc = (x, y) => x * y;
            ProcessDta pdd = new ProcessDta();
            pdd.ProcessViaFunction(3,5,addFunc);
            pdd.ProcessViaFunction(3, 5, mulFunc);

            Console.Read();
        }
    }


}
