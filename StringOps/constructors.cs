using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringOps
{
    /*http://jonskeet.uk/csharp/constructors.html
     public class MySimpleClass
{
    public MySimpleClass (int x)
    {
        Console.WriteLine (x);
    }
}
    The above is actually equivalent to:

public class MySimpleClass
{
    public MySimpleClass (int x) : base()
    {
        Console.WriteLine (x);
    }
} 
     * 
     * 
     * Note the base() bit. That's saying which other constructor should be invoked before any of the rest of the code in the constructor runs.  
     * IT MEANS THAT IF A CHILD CLASS CONSTRUCTOR SAYS NOTHING FOR BASE CONSTRUCTOR THEN ITS INTERNALLY CALLING BASE() WITHOUT ANY PARAMETER
     * NOW THE BASE() HAS TO RUN B4 ANYCODE OF CURRENT CONSTRUCTOR IS EXCUTED.
     
     * With the BELOW code, a bit of code saying new MyDerivedClass(); would invoke the MyDerivedClass parameterless constructor, 
     * which would in turn invoke the MyDerivedClass constructor which takes an int parameter (with 5 as that parameter value), 
     * which would in turn invoke the MyBaseClass constructor which takes an int parameter (with 6 as that parameter value). 
     * Note that the specified constructor is run before the constructor body, so the result of new MyDerivedClass(); would be the following output on the console:

        In the base class constructor taking an int, which is 6
        In the derived class constructor taking an int parameter.
        In the derived class parameterless constructor.
     * 
     * 
     * 
     * When a member variable declaration also has an assignment, that's called a variable initializer. All the variable initializers for a class are implicitly run directly before the invocation of whichever base class constructor is invoked. (Note that this is a change from a previous version of the page, where I believed that they were invoked after the base constructor, as they are in Java.) Here's a simple example of instance variable initializers:

public class MySimpleClass
{
    int someMemberVariable = 10;
                
    public MySimpleClass()
    {
        Console.WriteLine ("someMemberVariable={0}", someMemberVariable);
    }
}
The output of the above is 10 when a new instance is created, whereas without the instance variable initializer, it would be 0 (the default value for instance variables of type int). 
     * 
     */
    class constructors
    {
        public static void execute()
        {
            MyDerivedClass mdc = new MyDerivedClass();
        }
    }
    public class MyBaseClass
    {
        public MyBaseClass(int x): base() // Invoke the parameterless constructor in object
        {
            Console.WriteLine("In the base class constructor taking an int, which is " + x);
        }
    }

    public class MyDerivedClass : MyBaseClass
    {
        public MyDerivedClass()
            : this(5) // Invoke the MyDerivedClass constructor taking an int
        {
            Console.WriteLine("In the derived class parameterless constructor.");
        }

        public MyDerivedClass(int y)
            : base(y + 1) // Invoke the MyBaseClass constructor taking an int
        {
            Console.WriteLine("In the derived class constructor taking an int parameter.");
        }

        public MyDerivedClass(string x)
            : base(10) // Invoke the MyBaseClass constructor taking an int
        {
            Console.WriteLine("In the derived class constructor taking a string parameter.");
        }
    }
}
