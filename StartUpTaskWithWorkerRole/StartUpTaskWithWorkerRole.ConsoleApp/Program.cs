using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartUpTaskWithWorkerRole.ConsoleApp
{
    public class Program
    {
       public static void Main(string[] args)
        {
            Process process = Process.Start("calc.exe");
            process.WaitForExit();
            //Console.ReadLine();
        }
    }
}
