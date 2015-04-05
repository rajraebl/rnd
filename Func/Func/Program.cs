using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Func
{
    class Program
    {
        static void Main(string[] args)
        {
            //The first type parameters are the arguments to the methods, and the final type parameter is the return value.
            //The => operator separates arguments from methods body. Left side: This is the parameters.  Right side: This is a statement list 
            //The key part of Func is that it always returns a value.It can have zero,or many, arguments. But its mandatory to have a return value,
            //Action. This class indicates a function that receives no parameter and returns no value. It matches a void method with no arguments.


            //FULL SYNTAX: Create a Func instance that has one parameter and one return value. Parameter is an integer, result value is a string.
            Func<int, string> f1 = (int param1) => { return string.Format("input param is: {0}", param1); };
            ww(f1(2345));

            //Create a Func instance that has one parameter and one return value. Parameter is an integer, result value is a string.
            Func<int, string> f11 = (param1) => string.Format("input param is: {0}", param1);
            ww(f11(5678));
    
            //Func instance with two parameters and one result.... Receives bool & int, and returns string.
            Func<bool, int, string> f2 = (x, y) => string.Format("x={0}, y={1}", x, y);
            ww(f2.Invoke(true, 321));
    
            //Func Instance with no input param but one output param
            Func<double> f3 = () => Math.PI;
            ww(f3().ToString());

            // Use no parameters in a lambda expression.
            //The key part of Func is that it always returns a value.It can have zero,or many, arguments. But its mandatory to have a return value,
            //Action. This class indicates a function that receives no parameter and returns no value. It matches a void method with no arguments.
            Action func6 = () => Console.WriteLine("hello world");
            func6();

            //func<t>
            Func<int, int> square = num => num * num;
            Console.WriteLine(square(3));


            //below is a good example=========================================================
            Func<IEnumerable<int>, IEnumerable<int>> getGreaterThanTen = nums =>
            {
                var array = new List<int>();
                nums.ToList().ForEach(x =>
                {
                    if (x > 10)
                        array.Add(x);
                });
                return array;
            };

            IEnumerable<int> numbers = new[] { 3, 4, 7, 1, 8, 10, 21, 5, 9, 11, 14, 19 };
            var result = getGreaterThanTen(numbers);
            result.ToList().ForEach(Console.WriteLine);
            //==================================================================================

            Console.Read();
        }

        static void ww(string s)
        {
            Console.WriteLine(s);
        }

        int www(string s)
        {
            return s.Length;
        }
        //void www(string s)
        //{
        //    Console.WriteLine(s);
        //}
    }
}
