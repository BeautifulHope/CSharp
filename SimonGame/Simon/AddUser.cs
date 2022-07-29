using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;

namespace Simon2
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.name = this.textBox_username.Text;
            person.password = this.textBox_password.Text;
            string strSql = "insert into person (name,password) values(@name,@password)";
            SQLiteParameter[] paras = new SQLiteParameter[]
            {
                 new SQLiteParameter("@name",this.textBox_username.Text),
                 new SQLiteParameter("@password",this.textBox_password.Text)
            };
            if (SQLiteHelper.ExecSQL(strSql, paras))
            {
                MessageBox.Show("添加成功");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("删除失败");
            }
        }
    }
}
