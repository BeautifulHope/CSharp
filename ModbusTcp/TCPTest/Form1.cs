using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCPTest
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public Socket socket = null;

        public delegate void SetText(string text);

        private void Form1_Load(object sender, EventArgs e)
        {
            //实列化Socket
            socket = new  Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            IPAddress IpAdd = IPAddress.Parse("127.0.0.1");
            int port = 4399;
            IPEndPoint IpEnd = new IPEndPoint(IpAdd, port);

            try
            {
                socket.Connect(IpEnd);
            }
            catch (Exception)
            {

                //socket.Close();
                MessageBox.Show("连接失败!");
            }

            //multi thread for receiver data
            Thread th = new Thread(ReceiverData);
            th.IsBackground = true;
            th.Start();

        }

        /// <summary>
        ///防止跨线程给界面复制错误
        /// </summary>
        /// <returns></returns>
        public void SendText(string txt)
        {
            if (this.RecvText.InvokeRequired)//判断是否需要委托
            {
                SetText RichText = new SetText(SendText);
                this.Invoke(RichText, new object[] { txt});
            }
            else
            {
                this.RecvText.Text = txt;
            }
        }

        /// <summary>
        /// 接收数据
        /// </summary>
        /// <returns></returns>
        private void ReceiverData()
        {
            while(true)
            {
                byte[] ResBuffer = new byte[1024 * 2];//buffer
                int length = -1;//Buffer length

                //receiver data
                try
                {
                    length = socket.Receive(ResBuffer);
                }
                catch (SocketException ex)
                {
                    MessageBox.Show("SocketException!  " + ex.Message);
                    break;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("与服务器断开连接! "+ex.Message);
                }

                if (length > 0)//接收数据
                {
                    try
                    {
                        string msg = Encoding.Default.GetString(ResBuffer);
                        this.SendText(msg);
                        //this.RecvText.Text = msg;
                        Console.WriteLine(msg);

                        //length = -1;
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Encoding Error! Message:  " + ex.Message);
                    }
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine("Close");
            socket.Shutdown(SocketShutdown.Both);
        }
    }
}
