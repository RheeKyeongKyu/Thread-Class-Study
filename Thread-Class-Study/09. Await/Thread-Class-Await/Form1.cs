using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_Class_Await
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Update UI
            textBox1.Text = string.Empty;
            button1.Enabled = false;

            RunIt();
        }

        // async, await were introduced in C# 5.0
        // async informs the compiler that the method has await
        // await waits for the awaitable object to complete
        // await allows the compiler to automatically add the necessary code to keep the UI Thread running through the message loop

        // add async to the method
        private async void RunIt()
        {
            // Asynchronously Calling long running method
            Task<double> task = Task<double>.Factory.StartNew(() => LongCalc(10));

            // Wait for Task to end. (UI Thread will not be blocked)
            await task;

            // Update the value of the UI control after the task is completed
            // Code below will run in the UI Thread, so Invoke() is not needed
            textBox1.Text = task.Result.ToString();
            button1.Enabled = true;
        }

        private double LongCalc(int r)
        {
            // long running Task
            Thread.Sleep(3000);

            return 3.14 * r * r;
        }
    }
}
