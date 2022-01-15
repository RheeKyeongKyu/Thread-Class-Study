namespace Thread_Class_BackgroundWorker_Console
{
    using System;
    using System.ComponentModel;

    class Program
    {
        private BackgroundWorker worker;

        static void Main(string[] args)
        {
            new Program().Execute();
            Console.Read();
        }

        public void Execute()
        {
            //// Starting a Worker Thread from ThreadPool

            // Define BackgroundWorker Instance
            worker = new BackgroundWorker();

            // Specifying actual work to be done through DoWorkEventHandler
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);

            // Starting a task by callinng the RunWorkerAsync() method
            worker.RunWorkerAsync();
        }

        // Task method executed by Worker Thread
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Time consuming task
            Console.WriteLine("Long running task");
        }
    }
}
