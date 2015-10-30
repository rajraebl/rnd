using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * A is base class and B is child class . Class B inherits class A .

both class A and  B have static constructors .

i create instance of class B in main function then static constructor of class B executes before static constructor of class A.

while instance constructor of class A executes before Class B instance constructor .

Why there is difference for static constructor ?
 * 
 * 
 Static constructor is called when class is accessed first time. So the static constructor of B will be called first if you access the B, static constructor of A is not called until you use the A. If you use A first, then static constructor of A is called first and other way around.

For example in  the next code static constructor of A is not called at all because we don't access the A. So static functions do not construct similar calling chain as instance constructors.
internal class A
    {
        static A()
        {
            Console.WriteLine("A");
        }
    }

    internal class B : A
    {
        static B()
        {
            Console.WriteLine("B");
        }

        public static void Foo()
        {
            Console.WriteLine("Foo");
        }
    }

// calling
B.Foo();

// prints
B
Foo
 * */
namespace StringOps
{
    class staticConstructor
    {
    }
}

/*
 A static constructor does not take access modifiers or have parameters.
A static constructor is called automatically to initialize the class before the first instance is created or any static members are referenced.
 * If a static constructor throws an exception, the runtime will not invoke it a second time, and the type will remain uninitialized for the lifetime of the application domain in which your program is running.
 */
