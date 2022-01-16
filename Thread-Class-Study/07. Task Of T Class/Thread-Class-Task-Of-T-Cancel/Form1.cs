using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thread_Class_Task_Of_T_Cancel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 1. Declare CancellationTokenSource 필드
        private CancellationTokenSource cancelTokenSource;

        private void btnStart_Click(object sender, EventArgs e)
        {
            Run();
        }

        private async void Run()
        {
            // 2. Create CancellationTokenSource Instance
            cancelTokenSource = new CancellationTokenSource();
            CancellationToken token = cancelTokenSource.Token;

            // The StartNew method calls StartNew(Func, CancellationToken)
            // If the state of Token is in Cancel State, LongCalcAsync() will not be executed
            Task<object> task1 = Task.Factory.StartNew<object>(LongCalcAsync, token);

            dynamic res = await task1;
            if (res != null)
            {
                this.label1.Text = $"Sum: {res.Sum}";
            }
            else
            {
                this.label1.Text = "Cancelled";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 4. Cancel Task
            cancelTokenSource.Cancel();
        }

        private object LongCalcAsync()
        {
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                // 3. Check if the Task is cancelled
                if (cancelTokenSource.Token.IsCancellationRequested)
                {
                    return null;
                }
                sum += i;
                Thread.Sleep(1000);
            }

            return new { Sum = sum };
        }

    }
}
