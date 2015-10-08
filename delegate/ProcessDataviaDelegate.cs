using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @delegate
{
    public class ProcessDta
    {
        public void ProcessViaDelegate(int x, int y, BizRuleDelegate del) // here at runtime we r expecting the bizRule to b applied on x,y
        {
            var result = del(x, y);
            Console.WriteLine("ProcessViaDelegate {0} & {1} and result is {2}", x, y, result);
        }


        public void ProcessViaAction(int x, int y, Action<int, int> action)
        {
            action(x, y);
            Console.WriteLine("ProcessViaAction {0} &  {1} and action is {2}", x, y, action);
        }

        internal void ProcessViaFunction(int x, int y, Func<int, int, int> func)
        {
            var result = func(x, y);
            Console.WriteLine("ProcessViaFunction {0} & {1} and result is {2}", x, y, result);

        }
    }

}
