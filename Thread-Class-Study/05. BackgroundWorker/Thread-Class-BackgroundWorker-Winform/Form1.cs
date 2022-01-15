using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Thread_Class_BackgroundWorker_Winform
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BackgroundWorker worker;

        private void btnRun_Click(object sender, EventArgs e)
        {
            // Reset UI
            progressBar1.Value = 1;
            btnRun.Enabled = false;
            btnCancel.Enabled = true;

            // Set progress report and cancel property to true
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;

            // Assign event handler

            // DoWork event handler cannot access UI control
            worker.DoWork += new DoWorkEventHandler(Worker_DoWork);

            // ProgressChanged, RunWorkerCompleted event handler can access UI control (they both run in the UI Thread)
            worker.ProgressChanged += new ProgressChangedEventHandler(Worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(Worker_RunWorkerCompleted);

            // Start Worker Thread
            worker.RunWorkerAsync();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Reset UI
            btnRun.Enabled = true;
            btnCancel.Enabled = false;
            
            // Request cancellation of Worker Thread
            worker.CancelAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Upload 100 items
            int items = 100;
            for (int i = 1; i <= items; i++)
            {
                // Check if there are any request for cancellation of Worker Thread
                if (worker.CancellationPending)
                {
                    // Cancel running task using by setting 'e.Cancel' to true and return
                    e.Cancel = true;
                    return;
                }

                // Do upload task
                string fileName = $"Data_{i}.txt";
                Upload(fileName);

                // Report progress
                worker.ReportProgress(percentProgress: i, userState: fileName);
            }

            // Set the result of asynchronous task
            e.Result = items;
        }

        void Upload(string fileName)
        {
            Debug.WriteLine($"Uploading {fileName}");
            Thread.Sleep(100);
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update UI Control
            // Control.Invoke() not needed
            textBox1.Text = $"Progress : {e.ProgressPercentage}";
            progressBar1.PerformStep();
        }
        
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Update UI Control
            // Control.Invoke() not needed
            if (e.Cancelled)
            {
                textBox1.Text = "Task Cancelled";
            }
            else if (e.Error != null)
            {
                throw e.Error;
            }
            else
            {
                textBox1.Text = $"{e.Result} files uploaded";
            }
        }
    }
}
