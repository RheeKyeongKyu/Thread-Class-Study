using System;
using System.Threading;

namespace Thread_Class
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().DoTest();
        }

        private void DoTest()
        {
            // Execute Run() in new Thread (ManagedThreadId: 3)
            Thread thread1 = new Thread(new ThreadStart(Run));
            thread1.Start();

            // Execute Run() in main Thread (ManagedThreadId: 1)
            Run();
        }

        private void Run()
        {
            Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId}: Begin");

            // Wait for 3 seconds
            Thread.Sleep(3000);

            Console.WriteLine($"Thread#{Thread.CurrentThread.ManagedThreadId}: End");
        }
    }
}
