using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows;
using System.Collections;

namespace TCPClient
{
    public partial class Client : Form
    {
        public Client()
        {
            InitializeComponent();
            this.textBox1.Text = "4399";
        }

        Socket socketSend;

        public delegate void SetText(string text);

        /// <summary>
        /// 向服务器发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Environment.CurrentDirectory.ToString());
            send(textBox3.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //创建客户端Socket，获得远程ip和端口号
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse("127.0.0.1");
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(textBox1.Text));
                socketSend.Connect(point);
                ShowNotice("连接成功!");
                //开启新的线程，不停的接收服务器发来的消息
                Thread c_thread = new Thread(Received);
                c_thread.IsBackground = true;
                c_thread.Start();
            }
            catch (Exception)
            {
                ShowNotice("IP或者端口号错误...");
            }
        }

        void ShowMsg(string txt)
        {
            //richTextBox1.AppendText(str + "\r\n");
            if (this.richTextBox1.InvokeRequired)//判断是否需要委托
            {
                SetText RichText = new SetText(ShowMsg);
                this.Invoke(RichText, new object[] { txt });
            }
            else
            {
                this.richTextBox1.AppendText(txt + "\r\n");
            }
        }

        void ShowNotice(string str)
        {
            textBox4.AppendText(str + "\r\n");
        }

        void send(string msg)
        {
            try
            {
                byte[] buffer = new byte[1024 * 1024 * 3];
                buffer = Encoding.UTF8.GetBytes(msg);
                socketSend.Send(buffer);
            }
            catch { }
        }

        /// <summary>
        /// 接收服务端返回的消息
        /// </summary>
        void Received()
        {
            while (true)
            {

                    byte[] buffer = new byte[1024 * 1024 * 3];
                    //实际接收到的有效字节数
                    int len = socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, len);
                    ShowMsg(socketSend.RemoteEndPoint + ":" + str);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //int a = Convert.ToInt16(textBox2.Text);
                //if (a == -1)
                //{
                //    MessageBox.Show(a.ToString());
                //}
                socketSend.Shutdown(SocketShutdown.Both);
            }
            catch { }
        }

    }
}
