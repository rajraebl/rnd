using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolNmsp
{
    class Program
    {
       static WaitHandle[] waitHandles = new WaitHandle[]
            {
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };

        static void Main(string[] args)
        {// Queue the task.

            //NonStaticMethodCall();
            //WaitHandle_WaitAll();
            WaitHandle_WaitAny();
            cr();
       }

        static void WaitHandle_WaitAll()
        {
            DateTime dt = DateTime.Now;
            cc("MAIN THREAD WATING FOR BOTH THE TASKS TO BE COMPLETED");

            // Queue up two tasks on two different threads;
            ThreadPool.QueueUserWorkItem(new WaitCallback(x => TASK1(1000)), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(x => TASK2(5000)), waitHandles[1]);

            // wait until all tasks are completed.
            WaitHandle.WaitAll(waitHandles);

            // The time shown below should match the longest task.
            cc("BOTH TASKS COMPLETED IN :" + (DateTime.Now - dt).TotalMilliseconds);
        }
        static void WaitHandle_WaitAny()
        {
            DateTime dt = DateTime.Now;
            cc("MAIN THREAD WATING FOR BOTH THE TASKS TO BE COMPLETED");

            // Queue up two tasks on two different threads;
            ThreadPool.QueueUserWorkItem(new WaitCallback(x => TASK1(1000)), waitHandles[0]);
            ThreadPool.QueueUserWorkItem(new WaitCallback(x => TASK2(5000)), waitHandles[1]);

            // wait until any tasks are completed.
            WaitHandle.WaitAny(waitHandles);

            // The time shown below should match the shortest task.
            cc("BOTH TASKS COMPLETED IN :" + (DateTime.Now - dt).TotalMilliseconds);
        }


        private static void NonStaticMethodCall()
        {
            MyClass m = new MyClass();

            ThreadPool.QueueUserWorkItem(new WaitCallback(x => m.kk(6)));

            Console.WriteLine("Main thread does some work, then sleeps.");
            // If you comment out the Sleep, the main thread exits before 
            // the thread pool task runs.  The thread pool uses background 
            // threads, which do not keep the application running.  (This 
            // is a simple example of a race condition.)
            Thread.Sleep(10000);

            Console.WriteLine("Main thread exits.");

        }


        private static void TASK1(int i)
    {
        Thread.Sleep(i);
        cc("task compeleted: " + i);
            AutoResetEvent are = (AutoResetEvent) waitHandles[0];
            are.Set();
    }
        private static void TASK2(int i)
        {
            Thread.Sleep(i);
            cc("task compeleted: " + i);
            AutoResetEvent are = (AutoResetEvent)waitHandles[1];
            are.Set();

        }



        // This thread procedure performs the task. 
        static int ThreadProc(Object stateInfo) {
        // No state object was passed to QueueUserWorkItem, so  
        // stateInfo is null.
            Thread.Sleep(10000);

        Console.WriteLine("Hello from the thread pool.");
            return 5;
        }
        
        private static void cc(object s)
        {

            Console.WriteLine(s);
        }
        private static void cr()
        {

            Console.Read();
        }

    }

    class MyClass
    {
        public void kk(int i)
        {
            Console.Write("I am the non static method" + i);
        }
    }
}
