using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Class_Invoke
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RunTasks();
        }

        private static void RunTasks()
        {
            // Task Class VS Parallel Class
            // Task Class - Creates and executes 1,000 Threads if there are 1,000 Action Delegates
            // Parallel Class - Divide 1,000 Action Delegates into a set and allocate it to a small number of Threads

            // Parallel.Invoke() method provides execution of several tasks in Parallel
            Parallel.Invoke(
                () => { PrintNums(); },
                () => { PrintNums(); },
                () => { PrintNums(); },
                () => { PrintNums(); },
                () => { PrintNums(); }
            );
        }

        private static void PrintNums()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread = {Thread.CurrentThread.ManagedThreadId}, Num: {i}");
            }
        }
    }
}
