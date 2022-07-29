using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simon2
{
    public partial class Login : Form
    {

        public Login()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {

            if (this.textBox_username.Text.Length > 0)
            {
                string strSql = String.Format("select password from person where name = '{0}'", this.textBox_username.Text);
                Console.WriteLine("command:{0}", strSql);

                DataSet ds = SQLiteHelper.ExecuteQuery(strSql);
                if (ds != null && ds.Tables.Count > 0)
                {
                    //Console.WriteLine(ds.Tables[0]);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                        {
                            Console.WriteLine("{0}-{1}:{2}",i,j,ds.Tables[0].Rows[i][j].ToString());
                        }
                    }

                    if (this.textBox_password.Text == ds.Tables[0].Rows[0][0].ToString())
                    {
                        Console.WriteLine("Login Success!");
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("password wrong!", "ERROR");
                    }

                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            else
            {
                MessageBox.Show("username wrong!", "ERROR");
            }

            //if (this.textBox_username.Text == this.username)
            //{
            //    if (this.textBox_password.Text == this.password)
            //    {
            //        Console.WriteLine("Login Success!");
            //        this.DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        MessageBox.Show("password wrong!", "ERROR");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("username wrong!", "ERROR");
            //}
        }

        private void button_quit_Click(object sender, EventArgs e)
        {
            AddUser adduser = new AddUser();
            adduser.ShowDialog();
            //this.Close();
        }
    }
}
