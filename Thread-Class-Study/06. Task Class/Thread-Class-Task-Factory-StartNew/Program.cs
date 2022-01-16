using System;
using System.Threading.Tasks;

namespace Thread_Class_Task_Factory_StartNew
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Task Class
            // Gets Thread from ThreadPool executes Asynchronous operation
            // Similar to ThreadPool.QueueUserWorkItem(), but with improved performance and functionality
            // Normally, Task.Factory.StartNew() is used to specify the delegate for the method to run
            
            // Use Task.Factory to create Thread and start Thread
            Task.Factory.StartNew(action: new Action<object>(Run), state: null);
            Task.Factory.StartNew(action: new Action<object>(Run), state: "1st");
            Task.Factory.StartNew(action: Run, state: "2nd");
            
            Console.Read();
        }

        private static void Run(object data)
        {
            Console.WriteLine(data == null ? "NULL" : data);
        }
    }
}
