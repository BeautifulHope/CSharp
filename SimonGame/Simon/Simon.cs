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

namespace Simon2
{
    public partial class Simon : Form
    {
        private int[] data = new int[10];//data
        private int[] answer = new int[10];//data
        private int data_size = 10;
        private int level = 0;
        private int answer_locator = 0;

        Random rd = new Random();//random number
        Thread th;
        //Timer timer = new Timer();


        public Simon()
        {
            InitializeComponent();
            this.FlushText();


            this.myLED_R.LedStatus = false;
            //this.myLED_R.IsFlash = true;
            this.myLED_R.LedTrueColor = Color.Red;
            this.myLED_R.LedFalseColor = Color.White;

            this.myLED_G.LedStatus = false;
            //this.myLED_G.IsFlash = true;
            this.myLED_G.LedTrueColor = Color.Green;
            this.myLED_G.LedFalseColor = Color.White;

            this.myLED_B.LedStatus = false;
            //this.myLED_B.IsFlash = true;
            this.myLED_B.LedTrueColor = Color.Blue;
            this.myLED_B.LedFalseColor = Color.White;

            this.myLED_Y.LedStatus = false;
            //this.myLED_Y.IsFlash = true;
            this.myLED_Y.LedTrueColor = Color.Yellow;
            this.myLED_Y.LedFalseColor = Color.White;
        }

        private void GenerRandom()
        {
            for(int i = 0; i < this.level;i++)
            {
                this.data[i] = this.rd.Next(4);
                Console.WriteLine("{0}:{1}", i, data[i]);

                switch(data[i])
                {
                    case 0:
                        {
                            this.myLED_R.LedStatus = true;
                            Thread.Sleep(500);
                            break;
                        }
                    case 1:
                        {
                            this.myLED_G.LedStatus = true;
                            Thread.Sleep(500);
                            break;
                        }
                    case 2:
                        {
                            this.myLED_B.LedStatus = true;
                            Thread.Sleep(500);
                            break;
                        }
                    case 3:
                        {
                            this.myLED_Y.LedStatus = true;
                            Thread.Sleep(500);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("-----ERROR!-----");
                            break;
                        }
                }

                this.myLED_R.LedStatus = false;
                this.myLED_G.LedStatus = false;
                this.myLED_B.LedStatus = false;
                this.myLED_Y.LedStatus = false;
                Thread.Sleep(500);
            }
            Console.WriteLine("--------");
            //this.level++;
        }

        private void FlushText()
        {
            this.textBox1.Text = "Level:" + this.level.ToString();
        }

        private bool CheckResult()
        {
            bool result = false;
            for (int i = 0; i < data_size; i++)
            {
                if (this.data[i] != this.answer[i])
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        private void log(string flag)
        {
            Console.WriteLine(flag);
            foreach (int i in this.data)
                Console.Write("{0},", i);
            Console.WriteLine("");
            foreach (int i in this.data)
                Console.Write("{0},", i);
            Console.WriteLine("");
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            bool result = false;
            log("0");

            //起始判断
            if (this.button_Start.Text == "Start")
            {
                result = true;
                this.button_Start.Text = "Sure";
                this.level++;
            }
            else//判断上次的运行结果
            {
                result = this.CheckResult();
                this.level++;
            }

            if (result)
            {
                for (int i = 0; i < this.data_size; i++)//清楚answer
                    this.answer[i] = 0;
                this.answer_locator = 0;

                if (th == null || !th.IsAlive)
                {
                    th = new Thread(GenerRandom);//添加线程 
                    th.IsBackground = true;
                    th.Start();
                }
            }
            else
            {
                for (int i = 0; i < this.data_size; i++)
                    this.data[i] = 0;
                for (int i = 0; i < this.data_size; i++)
                    this.answer[i] = 0;
                this.level = 0;
                Console.WriteLine("----Clear----");
                this.button_Start.Text = "Start";

                MessageBox.Show("Answer wrong!", "ERROR");
                log("1");

            }

            //this.level = 10;
            this.FlushText();
        }

        private void button_ReStar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.data_size; i++)
                data[i] = 0;
            this.level = 0;
            Console.WriteLine("----Clear----");
            this.FlushText();
            this.button_Start.Text = "Start";
        }

        private void myLED_R_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.answer_locator < this.level)
            {
                this.answer[this.answer_locator] = 0;
                this.answer_locator++;
                Console.WriteLine("----myLED_R_MouseClick----");
            }
        }

        private void myLED_G_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.answer_locator < this.level)
            {
                this.answer[this.answer_locator] = 1;
                this.answer_locator++;
                Console.WriteLine("----myLED_G_MouseClick----");
            }
        }

        private void myLED_B_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.answer_locator < this.level)
            {
                this.answer[this.answer_locator] = 2;
                this.answer_locator++;
                Console.WriteLine("----myLED_B_MouseClick----");
            }
        }

        private void myLED_Y_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.answer_locator < this.level)
            {
                this.answer[this.answer_locator] = 3;
                this.answer_locator++;
                Console.WriteLine("----myLED_Y_MouseClick----");
            }
        }
    }
}
