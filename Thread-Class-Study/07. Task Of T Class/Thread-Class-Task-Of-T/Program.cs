using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Class_Task_Of_T
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and start Thread using Task<T>
            Task<int> task = Task.Factory.StartNew<int>(() => CalcSize("Hello World"));

            // Do other task in Main Thread
            Thread.Sleep(1000);

            // Return the Thread result (by result property)
            // If the Thread is running, wait for it to end
            int result = task.Result;

            Console.WriteLine($"Result={result}");
        }

        private static int CalcSize(string data)
        {
            string s = data == null ? "" : data.ToString();

            return s.Length;
        }
    }
}
