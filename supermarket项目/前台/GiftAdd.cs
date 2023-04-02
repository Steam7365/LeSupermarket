using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace supermarket项目
{
    public partial class GiftAdd : Form
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
        public GiftAdd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void GiftAdd_Load(object sender, EventArgs e)
        {

        }

        private void skinButton1_Click(object sender, EventArgs e)
        {

            string sql1 = $"select Count(*) from GoodsInfo where GInId='{textBox1.Text}' ";

            using (SqlConnection a = new SqlConnection(DBHelper.conn))
            {
                a.Open();
                SqlCommand b = new SqlCommand(sql1, a);
                int c = (int)b.ExecuteScalar();
                if (c < 1)
                {
                    MessageBox.Show("请输入正确的商品编号");
                    return;
                }
            }
            string sql = $"insert into Gift values({textBox1.Text},{textBox2.Text},{textBox3.Text})";
            using (SqlConnection a = new SqlConnection(DBHelper.conn))
            {
                try
                {
                    a.Open();
                    SqlCommand b = new SqlCommand(sql, a);
                    int c = b.ExecuteNonQuery();
                    if (c > 0)
                    {
                        MessageBox.Show("添加成功");
                    }
                    Class1.nb.Getthing("select * from GoodsInfo a join Gift b on a.GInId = b.GInId ");
                }
                catch 
                {

                }
               
            }

        }
    }
}
