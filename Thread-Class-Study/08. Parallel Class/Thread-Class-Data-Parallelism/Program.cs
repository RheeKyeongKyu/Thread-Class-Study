using System;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Class_Data_Parallelism
{
    class Program
    {
        // As multi-core CPUs become more common, demands on fully utilizing multi-core CPUs in programming has increased
        // To meet these needs, Parallel Framework(PFX) was added to .NET 4.0

        // Parallel Processing consists of following stages:
        // 1. Splitting up big tasks
        // 2. Execute the splitted tasks in parallel
        // 3. Aggregate the results

        // Method of splitting tasks(Parallel Framework (PFX)) is largely divided into:
        // 1. Data Parallelism - Refers to processing a large amount of data by dividing the work to each CPU core and perform parallel processing
        //                     - PLINQ (Parallel LINQ), Parallel Class (For/Foreach method)

        // 2. Task Parallelism - Divides a large task and each thread executes tasks separately
        //                     - Task / Task Factory Class, Parallel.Invoke() method

        static void Main(string[] args)
        {
            // Parallel Class provides processing splitted data in parallel by multi-threads on multi-core CPU through Parallel.For() / Parallel.ForEach() method

            // 1. Sequential Execution
            // Single Thread outputs 0 ~ 999
            for (int i = 0; i < 1000; i++)
            {
                // Outputs 0 ~ 999 in order
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            }
            Console.Read();

            // 2. Parallel Execution
            // Multi-Thread outputs 0 ~ 999
            Parallel.For(fromInclusive: 0, toExclusive: 1000, body: (i) =>
            {
                // 0 ~ 999 are not printed in order
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {i}");
            });
        }
    }
}
