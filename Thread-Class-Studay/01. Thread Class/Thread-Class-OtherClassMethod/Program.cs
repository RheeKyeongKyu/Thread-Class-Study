using System;
using System.Threading;

namespace Thread_Class_OtherClassMethod
{
    class Helper
    {
        public void Run()
        {
            Console.WriteLine("Helper.Run");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Calling Run() method of Helper class
            Helper obj = new Helper();
            Thread thread = new Thread(start: obj.Run);
            thread.Start();
        }
    }
}
