using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace EventLognmsps
{
    class Program
    {
        const string SourceName = "MyEventLogSource";

        static void Main(string[] args)
        {
            createLog();
            readLog();
            setUpPerformanceCounter();
        }

        static void createLog()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }

            EventLog.WriteEntry(SourceName, "I created this entry from comsole app on " + DateTime.Now.ToString());
            Console.WriteLine("event log entry created");
            Console.ReadLine();
        }
       static void readLog() {
           EventLog el = new EventLog("Application");
           Console.WriteLine("Total entries in the log are: " + el.Entries.Count);
           Console.ReadLine();
       }

       static void setUpPerformanceCounter() {
           string category = "My PerfC Category";

           //let us crete 2 counters in this category
       }
    }
}
