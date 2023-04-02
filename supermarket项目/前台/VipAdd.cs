using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supermarket项目
{
    public partial class VipAdd : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public VipAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("请正确填写信息");
                return;
            }
            if (textBox2.Text.Length != 11)
            {
                MessageBox.Show("请正确填写信息");
                return;
            }
            string a = DateTime.Now.ToString();
            string sql = $"insert into VipInfo values('{textBox1.Text}','{textBox2.Text}',default,0,'正常')";
            using (SqlConnection b = new SqlConnection(DBHelper.conn))
            {
                b.Open();
                SqlCommand c = new SqlCommand(sql, b);
                try
                {
                    int d = c.ExecuteNonQuery();
                    if (d > 0)
                    {
                        VIPCart cart = new VIPCart(textBox1.Text, textBox2.Text);
                        cart.ShowDialog();
                        Class1.add = true;
                    }
                }
                catch 
                {

                }
                

            }
            this.Close();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
