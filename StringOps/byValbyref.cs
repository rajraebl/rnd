using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOps
{
    class byValbyref
    {
       public static void Execute()
        {
            O o1 = new O();
            o1.prop = 1;

            O o2 = new O();
            o2.prop = 2;

            o1modifier(o1);
            o2modifier(ref o2);

            Console.WriteLine("1 : " + o1.prop.ToString()); // will return 1
            Console.WriteLine("2 : " + o2.prop.ToString()); // will return 4 as modified inside o2modifier
            Console.ReadLine();
        }

        static void o1modifier(O o)
        {
            o = new O(); // now o parameter points to a diffrent address in Heap. Any changes to that address will not reflect to the address pointed by o1.
            o.prop = 3;
        }

        static void o2modifier(ref O o)
        {
            o = new O(); //now o2 points to a new address. any changes to this will reflect to o2 as param o in this method points to refence of o2.
            o.prop = 4;
        }
    }

    class O
    {
        public int prop = 0;
    }
}
