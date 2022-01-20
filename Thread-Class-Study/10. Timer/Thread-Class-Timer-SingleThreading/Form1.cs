using System;
using System.Windows.Forms;

namespace Thread_Class_Timer_SingleThreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Use WinForm Timer
            // WinForm Timer Class executes in UI Thread and does not create additional Worker Thread
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        // Execute event handler every second
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Execute in UI Thread (can directly access UI Control)
            label1.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
