using System;
using System.Threading;

namespace Thread_Class_BackgroundForeground
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Foreground, Background Thread";
            Console.WriteLine("********** Foreground Vs Background **********");
            Console.WriteLine();
            Console.Write("Enter 1 to Start Foreground Thread and 2 to Start Background Thread (other to Exit): ");
                
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (number)
            {
                case 1:
                    StartForegroundThread();
                    break;
                case 2:
                    StartBackgroundThread();
                    break;
                default:
                    return;
            }

            // Main Thread
            Console.WriteLine("Main() method completed...");
        }


        private static void StartForegroundThread()
        {
            // Foreground Thread (default)
            // Keeps running even after main thread terminates
            Thread thread1 = new Thread(new ParameterizedThreadStart(Run));
            thread1.Start("Foreground Thread");
        }

        private static void StartBackgroundThread()
        {
            // Background Thread
            // Ends when main thread terminates
            Thread thread2 = new Thread(new ParameterizedThreadStart(Run));
            thread2.IsBackground = true;
            thread2.Start("Background Thread");
        }

        private static void Run(object threadType)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread Type: {threadType}, {i}");
                Thread.Sleep(1000);
            }
        }
    }
}
