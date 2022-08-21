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

namespace TCPServer
{
    public partial class Server : Form
    {

        public TcpListener myListener;
        public TcpClient newClient;
        public BinaryReader br;
        public BinaryWriter bw;
        public int i;

        public delegate void SetText(string text);

        public Server()
        {
            InitializeComponent();

            this.textBox2.Text = "4399";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        /// <summary>
        /// 等待客户端的连接 并且创建与之通信的Socket
        /// </summary>
        Socket socketSend;
        Socket socketWatch;
        void Listen(object o)
        {
            try
            {
                //Socket socketWatch = o as Socket;
                //while (true)
                //{
                socketSend = socketWatch.Accept();//等待接收客户端连接
                ShowMsg(socketSend.RemoteEndPoint.ToString() + ":" + "连接成功!");

                //开启一个新线程，执行接收消息方法
                Thread r_thread = new Thread(Received);
                r_thread.IsBackground = true;
                r_thread.Start();
                //}
            }
            catch { }
        }

        /// 服务器端不停的接收客户端发来的消息
        /// </summary>
        /// <param name="o"></param>
        void Received(object o)
        {
            try
            {
                //Socket socketSend = o as Socket;
                while (true)
                {
                    //客户端连接服务器成功后，服务器接收客户端发送的消息
                    byte[] buffer = new byte[1024 * 1024 * 3];
                    //实际接收到的有效字节数
                    int len = socketSend.Receive(buffer);
                    if (len == 0)
                    {
                        break;
                    }
                    string str = Encoding.UTF8.GetString(buffer, 0, len);//接收data
                    ShowMsg(socketSend.RemoteEndPoint + ":" + str);
                }
            }
            catch { }
        }

        /// <summary>
        /// 服务器向客户端发送消息
        /// </summary>
        /// <param name="str"></param>
        void Send(string str)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(str);
            socketSend.Send(buffer);
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
            textBox3.AppendText(str + "\r\n");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Send(richTextBox2.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {

                //点击开始监听时 在服务端创建一个负责监听IP和端口号的Socket
                socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress ip = IPAddress.Parse("127.0.0.1");//任意ip地址都可以
                //创建对象端口
                IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(textBox2.Text));
                socketWatch.Bind(point);//绑定端口号
                ShowNotice("监听成功!");
                socketWatch.Listen(10);//设置监听

                int point2 = Convert.ToInt32(textBox2.Text);
                TcpListener myListener = new TcpListener(IPAddress.Any, point2);//绑定端口IP信息

                myListener.Start();//开始监听

                //TcpClient newClient = myListener.AcceptTcpClient();//接受请求
                //newClient.Client.IOControl(IOControlCode.KeepAliveValues, KeepAlive(1, 30000, 10000), null);//设置Keep-Alive参数

                //创建监听线程
                Thread thread = new Thread(Listen);
                thread.IsBackground = true;
                thread.Start();

        }

        private byte[] KeepAlive(int onOff, int keepAliveTime, int keepAliveInterval)
        {
            byte[] buffer = new byte[12];
            BitConverter.GetBytes(onOff).CopyTo(buffer, 0);
            BitConverter.GetBytes(keepAliveTime).CopyTo(buffer, 4);
            BitConverter.GetBytes(keepAliveInterval).CopyTo(buffer, 8);
            return buffer;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            socketSend.Close();
            socketWatch.Close();
            ShowNotice("连接已断开!");
        }
    }
}
