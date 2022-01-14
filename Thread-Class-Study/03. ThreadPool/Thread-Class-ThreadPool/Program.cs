using System;
using System.Threading;

namespace Thread_Class_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            // Excutes Calc() Method by using a Thread in the ThreadPool
            // used when there is no return value
            // Calc() Method will be executed when ThreadPool thread becomes available
            ThreadPool.QueueUserWorkItem(callBack: Calc);               // radius = null
            ThreadPool.QueueUserWorkItem(callBack: Calc, state: 10.0);  // radius = 10
            ThreadPool.QueueUserWorkItem(callBack: Calc, state: 20.0);  // radius = 20

            // Wait for user input
            Console.ReadLine();
        }

        private static void Calc(object radius)
        {
            if (radius == null)
                return;

            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine($"r={r}, area={area}");
        }
    }
}
