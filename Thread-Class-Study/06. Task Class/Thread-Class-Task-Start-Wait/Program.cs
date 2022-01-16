using System;
using System.Threading.Tasks;

namespace Thread_Class_Task_Start_Wait
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Creating Task Instance

            // Method 1. Creating Task Instance by assigning Run method to Task constructor 
            Task t1 = new Task(new Action(Run));

            // Method 2. Creating Task Instance by lambda expression
            Task t2 = new Task(() =>
            {
                Console.WriteLine("Long query");
            });

            // Start Task Thread
            t1.Start();
            t2.Start();

            // Wait for Task to end
            t1.Wait();
            t2.Wait();
        }

        private static void Run()
        {
            Console.WriteLine("Long running method");
        }
    }
}
