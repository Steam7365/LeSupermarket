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
    public partial class VipInfo : Form
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
        public VipInfo()
        {
            InitializeComponent();
        }
        public void GetVip(string sql)
        {
            using (SqlConnection a = new SqlConnection(DBHelper.conn))
            {
                DataSet b = new DataSet();
                SqlDataAdapter c = new SqlDataAdapter(sql, a);
                c.Fill(b);
                dataGridView1.DataSource = b.Tables[0];
            }
            //this.dataGridView1.Rows[0].Selected = false;
        }
        private void VipInfo_Load(object sender, EventArgs e)
        {
            string sql = "select * from VipInfo";
            GetVip(sql);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            this.dataGridView1.Rows[0].Selected = false;
            //   dataGridView1.Rows.select = false;
            //this.BackColor = Color.FromArgb(255, 255, 255);
            //this.pictureBox1.BackColor = Color.FromArgb(255, 255, 255);
            b = true;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 信息修改DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            string sql = $@"update VipInfo 
                            set Name='{dataGridView1.SelectedRows[0].Cells[1].Value.ToString()}',
                            Phone='{dataGridView1.SelectedRows[0].Cells[2].Value}',
                            StartTime='{(Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())).ToString("yyyy-MM-dd HH:mm:ss")}',
                            Score='{dataGridView1.SelectedRows[0].Cells[4].Value.ToString()}',
                            Statue='{dataGridView1.SelectedRows[0].Cells[5].Value.ToString()}' 
                            where Phone='{dataGridView1.SelectedRows[0].Cells[2].Value.ToString()}'";
            using (SqlConnection a = new SqlConnection(DBHelper.conn))
            {
                a.Open();
                SqlCommand b = new SqlCommand(sql, a);
                int c = b.ExecuteNonQuery();
                if (c > 0)
                {
                    MessageBox.Show("修改成功");
                }
                GetVip("select * from VipInfo");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            GetVip($"select * from VipInfo where 1=1 and Phone like '%{textBox1.Text}%'");
        }

        private void 会员注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Point b = new Point(this.textBox2.Location.X, this.textBox2.Location.Y);
            //this.textBox2.Location = new Point(textBox2.Location.X - 2, textBox2.Location.Y - 2);
            //Thread.Sleep(100);
            //this.textBox2.Location = b;
            //VipUpdate a = new VipUpdate();
            //a.Show();
            string phone = dataGridView1.SelectedRows[0].Cells["Column3"].Value.ToString();
            DialogResult b = MessageBox.Show($"是否确定删除号码为{phone}的手机号", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (b == DialogResult.Yes)
            {
                string sql2 = $"delete VipInfo  where Phone='{phone}'";
                using (SqlConnection a = new SqlConnection(DBHelper.conn))
                {
                    a.Open();
                    SqlCommand c = new SqlCommand(sql2, a);
                    try
                    {
                        int d = c.ExecuteNonQuery();
                        if (d > 0)
                        {
                            MessageBox.Show("删除成功");
                        }
                        else
                        {
                            MessageBox.Show("该会员不存在，请检查号码是否有误");
                        }
                    }
                    catch 
                    {

                    }
                }
                string sql = "select * from VipInfo";
                GetVip(sql);
            }
            else
            {
                return;
            }
        }

        private void 注册会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VipAdd a = new VipAdd();
            a.ShowDialog();
            if (Class1.add)
            {
                GetVip("select * from VipInfo");
                Class1.add = false;
            }
        }
        bool b = false;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (b)
            {
                string sql = $@"update VipInfo 
                            set Name='{dataGridView1.SelectedRows[0].Cells[1].Value.ToString()}',
                            Phone='{dataGridView1.SelectedRows[0].Cells[2].Value}',
                            StartTime='{(Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells[3].Value.ToString())).ToString("yyyy-MM-dd HH:mm:ss")}',
                            Score='{dataGridView1.SelectedRows[0].Cells[4].Value.ToString()}',
                            Statue='{dataGridView1.SelectedRows[0].Cells[5].Value.ToString()}' 
                            where Phone='{dataGridView1.SelectedRows[0].Cells[2].Value.ToString()}'";
                using (SqlConnection a = new SqlConnection(DBHelper.conn))
                {
                    try
                    {
                        a.Open();
                        SqlCommand b = new SqlCommand(sql, a);
                        int c = b.ExecuteNonQuery();
                        GetVip("select * from VipInfo");
                    }
                    catch 
                    {
                    }
                }
            }

        }
    }
}
