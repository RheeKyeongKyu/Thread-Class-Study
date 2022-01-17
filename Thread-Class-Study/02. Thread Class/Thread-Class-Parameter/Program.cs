using System;
using System.Threading;

namespace Thread_Class_Parameter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using ThreadStart without parameters
            Thread thread1 = new Thread(new ThreadStart(Run));
            thread1.Start();

            // Passing (object type)parameter to ParameterizedThreadStart
            // Passing radius as parameter of Start()
            Thread thread2 = new Thread(start: new ParameterizedThreadStart(Calc));
            thread2.Start(10.00);

            // Passing parameter in ThreadStart
            Thread thread3 = new Thread(() => Sum(10, 20, 30));
            thread3.Start();

            // Passing array of object as parameter to ParameterizedThreadStart
            Thread thread4 = new Thread(start: new ParameterizedThreadStart(Multiplication));
            thread4.Start(new object[5] {1, 3, 5, 7, 9});
        }


        private static void Run()
        {
            Console.WriteLine("Run");
        }

        // Accept radius parameter as object type
        private static void Calc(object radius)
        {
            double r = (double)radius;
            double area = r * r * 3.14;
            Console.WriteLine($"r={r}, area={area}");
        }

        private static void Sum(int d1, int d2, int d3)
        {
            int sum = d1 + d2 + d3;
            Console.WriteLine($"Sum: {sum}");
        }

        private static void Multiplication(object numbers)
        {
            Array nums = (Array)numbers;

            int result = 1;
            for (int i = 0; i < nums.Length; i++)
            {
                result *= (int)nums.GetValue(i);
            }

            Console.WriteLine($"Multiplication: {result}");
        }
    }
}
