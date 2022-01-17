using System;
using System.Threading;

namespace Thread_Class_Asynchronous_Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create Func Delegate Instance by using GetArea() Method
            // First two int of Func is for input, last int is for output
            Func<int, int, int> work = GetArea;

            // Execute BeginInvoke() by Delegate Instance
            // Assign two input parameters
            // The return value asyncResult tells which Thread it points to
            IAsyncResult asyncResult = work.BeginInvoke(arg1: 10, arg2: 20, callback: null, @object: null);

            Console.WriteLine("(Do something in Main Thread)");

            // Exeute EndInvoke(IAsyncResult) by Delegate Instance
            // EndInvoke waits for Thread to end and gets return value
            int result = work.EndInvoke(asyncResult);

            Console.WriteLine($"Result: {result}");
        }

        private static int GetArea(int height, int width)
        {
            int area = height * width;
            return area;
        }
    }
}
