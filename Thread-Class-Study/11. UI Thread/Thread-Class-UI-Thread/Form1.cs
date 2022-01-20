using System;
using System.Threading;
using System.Windows.Forms;

namespace Thread_Class_UI_Thread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // UI Thread: Thread that creates UI Control and owns the Window Handle of the Control
        // Worker Thread: Thread that does not own the UI Control

        // Normally, a UI Program has one UI Thread and multiple Worker Thread (But Possible to have multiple UI Thread)

        Thread worker;

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // Update UI Control by UI Thread
            btnQuery.Enabled = false;
            btnCancel.Enabled = true;
            textBox1.Text = string.Empty;

            // Start Worker Thread
            worker = new Thread(Run);
            worker.Start();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Abort Worker Thread
            worker.Abort();

            // Update UI Control by UI Thread
            btnQuery.Enabled = true;
            btnCancel.Enabled = false;

            // Refresh TextBox by UI Thread
            UpdateTextBox("Query Cancelled");
        }

        private void Run()
        {
            // Long running DB query
            Thread.Sleep(5000);

            // Refresh TextBox by Worker Thread
            UpdateTextBox("Query Result");
        }

        private void UpdateTextBox(string data)
        {
            // Check if calling Thread is Worker Thread
            if (textBox1.InvokeRequired)
            {
                // If it is Worker Thread
                textBox1.BeginInvoke(new Action(() =>
                {
                    textBox1.Text = data;
                    btnQuery.Enabled = true;
                    btnCancel.Enabled = false;
                }));
            }
            else
            {
                // If it is UI Thread
                textBox1.Text = data;
                btnQuery.Enabled = true;
                btnCancel.Enabled = false;
            }
        }
    }
}
