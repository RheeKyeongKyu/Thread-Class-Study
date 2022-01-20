using System;
using System.IO;
using System.Net;
using System.Timers;

namespace Thread_Class_Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Timer in .NET consist of following class:
            // Classes that support Multi-Threading
            //   - System.Threading.Timer
            //   - System.Timers.Timer
            // Classes that only support Single-Threading
            //   - System.Windows.Forms.Timer
            //   - System.Windows.Threading.DispatcherTimer

            // Timer classes that support multi-threading use event handlers that run at specific intervals using worker threads allocated by the thread pool,
            // and there is no guarantee that the same worker thread will always run the event handler.
            // If the event handler executes longer than the next interval, another worker thread runs the handler.

            // Create and start Timer
            Timer timer = new Timer();
            timer.Interval = 30 * 1000; // 30 seconds
            timer.Elapsed += new ElapsedEventHandler(Timer_Elapsed);
            timer.Start();

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }

        // Worker Thread in the ThreadPool run the below event handler in specified interval
        private static void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Download webpage HTML text
            WebClient web = new WebClient();
            string webPage = web.DownloadString("http://mssql.tools");

            // Save downloaded content into a file
            string time = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            string outputfile = $"Page_{time}.html";
            File.WriteAllText(outputfile, webPage);
        }


    }
}
