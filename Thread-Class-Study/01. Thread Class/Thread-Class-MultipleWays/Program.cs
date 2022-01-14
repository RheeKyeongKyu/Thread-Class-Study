using System;
using System.Threading;

namespace Thread_Class_MultipleWays
{
    class Program
    {
        static void Main(string[] args)
        {
            // Below are multiple methods for constructing Thread

            // Method 1.
            // Construct ThreadStart Delegate type object
            // and send it to constructor of Thread class
            Thread thread1 = new Thread(start: new ThreadStart(Run));
            thread1.Start();

            // Method 2.
            // Compiler creates a ThreadStart Delegate object
            // by inferring it from the function prototype of Run() method
            Thread thread2 = new Thread(start: Run);
            thread2.Start();

            // Method 3.
            // Create Thread by Anonymous Method
            Thread thread3 = new Thread(start: delegate()
            {
                Run();
            });
            thread3.Start();

            // Method 4.
            // Create Thread by Lambda Expression
            Thread thread4 = new Thread(() => Run());
            thread4.Start();

            // Method 5.
            // Simplified expression
            new Thread(() => Run()).Start();
        }

        private static void Run()
        {
            Console.WriteLine($"Run Thread: {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
