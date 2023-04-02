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
    public partial class VipUpdate : Form
    {
        public VipUpdate()
        {
            InitializeComponent();
        }

        

        private void VipUpdate_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(225, 225, 225);
            this.BackColor = Color.FromArgb(225, 225, 225);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult b = MessageBox.Show($"是否确定注销号码为{textBox1.Text}的手机号", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (b == DialogResult.Yes)
            {
                string sql = $"delete VipInfo  where Phone='{textBox1.Text}'";
                using (SqlConnection a = new SqlConnection(DBHelper.conn))
                {
                    a.Open();
                    SqlCommand c = new SqlCommand(sql, a);
                    int d = c.ExecuteNonQuery();
                    if (d > 0)
                    {
                        MessageBox.Show("注销成功");
                    }
                    else
                    {
                        MessageBox.Show("该会员不存在，请检查号码是否有误");
                    }
                }
            }
            else
            {
                return;
            }

        }
    }
}
