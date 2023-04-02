using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace supermarket项目
{
    public partial class MainFrom : Form
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
        public MainFrom()
        {
            InitializeComponent();
        }
        public void Getthing(string sql)
        {
            using (SqlConnection a = new SqlConnection(DBHelper.connStr))
            {
                DataSet b = new DataSet();
                SqlDataAdapter c = new SqlDataAdapter(sql, a);
                c.Fill(b);
                dataGridView1.DataSource = b.Tables[0];
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.dataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            this.BackColor = Color.FromArgb(255, 255, 255);
            dataGridView1.AutoGenerateColumns = false;
            Getthing("select * from GoodsInfo a join Gift b on a.GInId = b.GInId");
            b = true;

        }
        int cc ;

        int dd ;
        string aaaa;
        public void Change(int ccc)
        {
            
            string sql = $"select GInId  from GoodsInfo where Gname='{dataGridView1.SelectedRows[0].Cells[1].Value}' ";
            MessageBox.Show(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
            using (SqlConnection a = new SqlConnection(DBHelper.conn))

            {
              //  MessageBox.Show(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                SqlConnection bbb = new SqlConnection(DBHelper.conn);
                bbb.Open();
                SqlCommand b = new SqlCommand(sql, bbb);
                SqlDataReader c = b.ExecuteReader();
                if (c.Read())
                {
                    dd = (int)c["GInId"];
                    Class1.ww = (int)c["GInId"];

                }
                else
                {
                    MessageBox.Show("3");
                }
                a.Close();
            }
            string sql1 = $"select Much from Gift where GInId='{dd}' ";
            using (SqlConnection p = new SqlConnection(DBHelper.conn))
            {
                // MessageBox.Show(dataGridView1.SelectedRows[0].Cells[1].Value.ToString());
                aaaa = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                p.Open();
                SqlCommand d = new SqlCommand(sql1, p);
                SqlDataReader f = d.ExecuteReader();
                if (f.Read())
                {
                    cc = (int)f["Much"];
                }
                else
                {
                    MessageBox.Show("2");
                }
                p.Close();
            }


            string sql2 = $"update Gift set Much={cc - ccc }where GInId='{dd}'";
            using (SqlConnection aaa = new SqlConnection(DBHelper.conn))
            {
                aaa.Open();
                SqlCommand cccc = new SqlCommand(sql2, aaa);
                int ddddd = cccc.ExecuteNonQuery();
                if (ddddd > 0)
                {
                    MessageBox.Show("兑换成功");
                }
                else
                {
                    MessageBox.Show("1");
                }
            }
            Getthing("select * from GoodsInfo a join Gift b on a.GInId = b.GInId");
        }

      

        private void 多个礼品兑换HToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                Class1.nb = this;
                GiftChange a = new GiftChange((int)dataGridView1.SelectedRows[0].Cells[2].Value );
                a.ShowDialog();

            
        }

        private void 添加礼品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Class1.nb = this;
            GiftAdd a = new GiftAdd();
            a.Show();
        }

        private void 礼品删除SToolStripMenuItem_Click(object sender, EventArgs e)
        {
          DialogResult d=  MessageBox.Show("是否确认删除","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if (d==DialogResult.Yes)
            {
                string sql = $"delete Gift Where GiftID='{dataGridView1.SelectedRows[0].Cells[0].Value}'";
                using (SqlConnection a = new SqlConnection(DBHelper.conn))
                {
                    a.Open();
                    SqlCommand b = new SqlCommand(sql, a);
                    int c = b.ExecuteNonQuery();
                    if (c > 0)
                    {
                        MessageBox.Show("删除成功");
                        Getthing("select * from GoodsInfo a join Gift b on a.GInId = b.GInId");
                    }
                }

            }
        }
        bool b = false;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (b)
            {
                string sql = $@"update Gift 
                            set score='{dataGridView1.SelectedRows[0].Cells["Column3"].Value.ToString()}',
                            Much='{dataGridView1.SelectedRows[0].Cells["Column4"].Value}'
                            where GiftId='{dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString()}'";
                using (SqlConnection a = new SqlConnection(DBHelper.conn))
                {
                    try
                    {
                        a.Open();
                        SqlCommand b = new SqlCommand(sql, a);
                        int c = b.ExecuteNonQuery();
                        Getthing("select * from GoodsInfo a join Gift b on a.GInId = b.GInId");
                    }
                    catch
                    {
                    }
                }
            }
        }
    }   
}
