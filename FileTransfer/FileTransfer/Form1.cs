using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace FileTransfer
{
    public partial class Form1 : Form
    {
        public static string targetPath = "TestReport_ForNAS";

        public Form1()
        {
            InitializeComponent();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HHmmss"));

            System.Threading.Timer timer = new System.Threading.Timer((state) => 
            {
                state += $"任务线程:{Thread.CurrentThread.ManagedThreadId} " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " isThreadPool:" + Thread.CurrentThread.IsThreadPoolThread;
                Console.WriteLine(state);
                Console.WriteLine(PathAndIni.filePath);
            }, "", 5000, 1000);

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("程序将最小化到系统托盘");

            e.Cancel = true;
            this.Hide();
            this.ShowInTaskbar = false;
            this.notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }
    }
}
