using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threadnmsp
{
    class Program
    {
        static  void Main(string[] args)
        {
            //Thread t = new Thread(p1);
            //t.IsBackground = false;
            //t.Start();
            AsyncGreetCaller();
            webClient();
            p1();
            MultipleAsyncMethodsWithCombinators();
            cr();
        }

        static string Greet(string name)
        {
            Thread.Sleep(3000);
            return string.Format("Hello Dear {0}", name);
        }

        static Task<string> GreetAsync(string name) // this wrapper is needed as the AsyncGreetCaller method can await only a method that is awaitable(Async, Task, Task<T>)
        {
            //We will create our Task using Task.Run<T> method. This method Queues the specified work to run on the ThreadPool and returns a task handle for that work.
            return Task.Run<string>(() => { return Greet(name); });
        }


        public static void webClient()
        {
            Task<string> t = Task<string>.Factory.StartNew(() =>
            {
                var web = new WebClient();
                string result = web.DownloadString("http://www.rediff.com/");
                return result;
            });
            cc("continuing on main thread");
            cc(t.Result);
        }


        static async void AsyncGreetCaller()
        {
            cc("Starting AsyncGreetCaller");

            string result = await GreetAsync("Raje");
            cc(result);

        }

        public static void p1()
        {
            cc("Starting p1");
            Thread.Sleep(3000);
            cc("Ending p1");
        }


        public async static void MultipleAsyncMethodsWithCombinators()
        {
            Task<string> t1 = GreetAsync("Raje");
            Task<string> t2 = GreetAsync("Hariom");

            await Task.WhenAll(t1, t2);

            cc("MultipleAsyncMethodsWithCombinators Done");
            Console.WriteLine("Finished both methods.\n " +

                        "Result 1: {0}\n Result 2: {1}", t1.Result, t2.Result);
        }


        //public static void p2()
        //{
        //    cc("Starting p2");
        //    Thread.Sleep(5000);
        //    cc("Ending p2");
        //}

        //public static async void p3()
        //{
        //    cc("Starting p3");
        //    await p4();
        //    cc("Ending p3");
        //}


        //public async static Task<string> p4()
        //{
        //    Thread.Sleep(5000);
        //    return "I am Done p4";
        //}

        private static void cc(object s)
        {
            Console.WriteLine(s);
        }
        private static void cr()
        {
            Console.Read();
        }

    }
}
