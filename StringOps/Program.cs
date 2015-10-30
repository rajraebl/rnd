using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringOps.Polymorphism;

namespace StringOps
{
    class Program
    {
        static void Main(string[] args)
        {
            //StringComparision();
            //PrintEnumType();
            //Fibonacci(15);


            //Method_Overriding_and_Hiding();

            //BubbleSorting.Sort(new[] { 800, 11, 50, 771, 649, 770, 240, 9 });
            //QuickSorting.Sort(new[] { 800, 11, 50, 771, 649, 770, 240, 9 }, 0,7);

            //byValbyref.Execute();
            constructors.execute();
            Console.Read();
        }

        private static void Method_Overriding_and_Hiding()
        {//http://www.dotnet-tricks.com/Tutorial/csharp/U33Y020413-Understanding-virtual,-override-and-new-keyword-in-C
            A a = new A();
            B b = new B();
            C c = new C();

            a.Test(); // output --> "A::Test()"
            b.Test(); // output --> "B::Test()"
            c.Test(); // output --> "C::Test()"

            a = new B();
            a.Test(); // output --> "A::Test()"

            b = new C();
            b.Test(); // output --> "C::Test()"
        }

        private static void StringComparision()
        {
            String s1 = "Strasse";
            String s2 = "Straße";
            Boolean eq;



            Console.WriteLine("Normal comparison: " + (s1 == s2));


            // CompareOrdinal returns nonzero.
            eq = String.Compare(s1, s2, StringComparison.Ordinal) == 0;
            Console.WriteLine("Ordinal comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

            eq = string.Compare(s1, s2, StringComparison.CurrentCulture) == 0;
            Console.WriteLine("CurrentCulture comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");

            // Compare Strings appropriately for people // who speak German (de) in Germany (DE)
            CultureInfo ci = new CultureInfo("de-DE");
            // Compare returns zero.
            eq = String.Compare(s1, s2, true, ci) == 0;
            Console.WriteLine("Cultural comparison: '{0}' {2} '{1}'", s1, s2, eq ? "==" : "!=");
        }

        private static void PrintEnumType()
        {
            // The following line displays "System.Byte".
            Console.WriteLine(Enum.GetUnderlyingType(typeof(Color)));

        }


        private static void Fibonacci(int n)
        {
            int a = 0, b = 1, c=1;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a);
                a = b;
                b = c;
                c = a + b;
            }
        }
    }


    //Every enumerated type has an underlying type, which can be a byte, sbyte, short, ushort, int (the most common
    //type and what C# chooses by default), uint, long, or ulong.
    internal enum Color : byte
    {
        White,
        Red,
        Green,
        Blue,
        Orange
    }


    namespace Polymorphism
    {
        internal class A
        {
            public void Test()
            {
                Console.WriteLine("A::Test()");
            }
        }

        internal class B : A
        {
            public new virtual void Test()
            {
                Console.WriteLine("B:Method Hiding:Test()");
            }
        }

        internal class C : B
        {
            public override void Test()
            {
                Console.WriteLine("C:Method Overriding:Test()");
            }
        }


    }
}
