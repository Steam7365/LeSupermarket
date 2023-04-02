using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace supermarket项目
{
    public partial class GiftChange : Form
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
        public int ccc;
        public GiftChange(int score)
        {
            ccc = score;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public int aaaa;
        private void button1_Click(object sender, EventArgs e)
        {
            
        }


        private void GiftChange_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                return;
            }
            if (textBox2.Text == "")
            {
                return;
            }
            aaaa = int.Parse(textBox1.Text);
            string sql1 = $"select Count(*) from VipInfo where Phone ='{textBox2.Text}' ";
            using (SqlConnection a = new SqlConnection(DBHelper.conn))
            {
                try
                {
                    a.Open();
                    SqlCommand b = new SqlCommand(sql1, a);
                    int c = (int)b.ExecuteScalar();
                    a.Close();
                    if (c > 0)
                    {
                        string sql3 = $"select Score From Vipinfo where Phone='{textBox2.Text}'";
                        using (SqlConnection t = new SqlConnection(DBHelper.conn))
                        {

                            t.Open();
                            SqlCommand f = new SqlCommand(sql3, t);
                            int score = (int)f.ExecuteScalar();
                            ccc = aaaa * ccc;
                            if (score - ccc > 0)
                            {
                                string sql2 = $"update VipInfo set Score-={ccc} where Phone='{textBox2.Text}' ";
                                using (SqlConnection d = new SqlConnection(DBHelper.conn))
                                {
                                    d.Open();
                                    SqlCommand z = new SqlCommand(sql2, d);
                                    int q = z.ExecuteNonQuery();
                                    z.Clone();
                                }
                                Class1.nb.Change(int.Parse(textBox1.Text));
                                string sql4 = $"insert into GiftChange values('{textBox2.Text}',{Class1.ww},getdate(),'{textBox1.Text}','{Chanzhi.BID}')";

                                using (SqlConnection aa = new SqlConnection(DBHelper.conn))
                                {
                                    aa.Open();
                                    SqlCommand bb = new SqlCommand(sql4, aa);
                                    int q = bb.ExecuteNonQuery();
                                    bb.Clone();
                                }
                            }
                            else
                            {
                                MessageBox.Show("积分不足");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("请输入正确会员号");
                        return;
                    }

                }
                catch 
                {

                }
            }
            skinButton1.Location = new Point(skinButton1.Location.X - 5, skinButton1.Location.Y - 5);
            Thread.Sleep(100);
            skinButton1.Location = new Point(skinButton1.Location.X + 5, skinButton1.Location.Y + 5);


        }
    }
}
