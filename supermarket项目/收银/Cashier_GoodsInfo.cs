using CCWin;
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
    public partial class Cashier_GoodsInfo : Form
    {
        /// <summary>
        /// 防止窗体闪烁
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        public Cashier_GoodsInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 过期商品与数量不足
        /// </summary>
        public void JinGao()
        {

            string sql = @"select i.*,t.GType from GoodsInfo i join GoodsType t
                            on i.GId = t.GId  where Gcount <10";

            DataSet b = new DataSet();

            using (SqlConnection a = new SqlConnection(DBHelper.connStr))
            {
                a.Open();
                SqlDataAdapter c = new SqlDataAdapter(sql, a);
                c.Fill(b);
                dataGridView1.DataSource = b.Tables[0];
            }

        }

        private void Cashier_GoodsInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            //查看语句
            string sql = @"select i.*,t.GType from GoodsInfo i join GoodsType t
                            on i.GId = t.GId";
            GetLook(sql);
            //把当前窗体传值过去
            DBHelper.GoodsInfo = this;
        }
        /// <summary>
        /// 商品信息表显示在视图中
        /// </summary>
        /// <param name="sql">命令语句</param>
        public void GetLook(string sql)
        {
            DataSet dSet = new DataSet();
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                try
                {
                    SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                    sda.Fill(dSet);
                    dataGridView1.DataSource = dSet.Tables[0];
                }
                catch
                {
                    MessageBox.Show("类型编号不明确");
                }

            }
            //判断商品数量是否小于10
            //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            //{
            //    if (int.Parse(dataGridView1.Rows[i].Cells["Column6"].Value.ToString()) <= 200)
            //    {
            //        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
            //        //dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
            //    }
            //}

        }
        /// <summary>
        /// 点击图片按钮发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// 流动当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        /// <summary>
        /// 右键触发打开添加窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmGoodsInfoAdd GoodsAdd = new FrmGoodsInfoAdd();
            GoodsAdd.ShowDialog();
        }
        /// <summary>
        /// 右键触发打开修改窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 修改商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBHelper.dgv = dataGridView1;//将当前视图保存起来
            //判断是否选中商品
            if (DBHelper.dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中要修改的商品！！");
                return;
            }
            //打开修改窗体
            FrmGoodsInfoAlter GoodsAlter = new FrmGoodsInfoAlter();
            GoodsAlter.ShowDialog();
        }
        /// <summary>
        /// 删除选中的商品
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //判断是否选中商品
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中要删除的商品！！");
                return;
            }
            DialogResult dr = MessageBox.Show("是否确定删除商品！！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr == DialogResult.OK)
            {
                //获取选中的商品编号并删除
                string str = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string sql = "delete Gift where GInId=@GInId";
                using (SqlConnection con = new SqlConnection(DBHelper.connStr))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        try
                        {
                            com.Parameters.Add(new SqlParameter("@GInId", str));
                            int r = com.ExecuteNonQuery();
                            if (r != 0)
                            {
                            }
                        }
                        catch
                        { }

                    }
                }
                sql = "delete GoodsInfo where GInId=@GInId";
                using (SqlConnection con = new SqlConnection(DBHelper.connStr))
                {
                    con.Open();
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.Parameters.Add(new SqlParameter("@GInId", str));
                        int r = com.ExecuteNonQuery();
                        if (r != 0)
                        {
                            MessageBox.Show("删除成功！！");
                        }
                    }
                }
                GetLook("select * from GoodsInfo");
            }
        }
        /// <summary>
        /// 关闭时发生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_GoodsInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // pictureBox1_Click(sender, e);
        }

        private void 数量紧缺ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JinGao();
        }

        private void 过期食品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet b = new DataSet();

            using (SqlConnection a = new SqlConnection(DBHelper.connStr))
            {
                string sql = @"select i.*,t.GType from GoodsInfo i join GoodsType t
                            on i.GId = t.GId";
                a.Open();
                SqlDataAdapter c = new SqlDataAdapter(sql, a);
                c.Fill(b);
                dataGridView1.DataSource = b.Tables[0];
            }
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                int g;
                string d = dataGridView1.Rows[i].Cells["Column7"].Value.ToString();//生产日期
                int z = d.IndexOf("/");
                int zz = d.LastIndexOf("/");
                if (zz < 7)
                {   //截取月份
                    g = int.Parse(d.Substring(z + 1, 1));
                }
                else
                {  //截取月份
                    g = int.Parse(d.Substring(z + 1, 2));
                }
                // 截取年份
                int q = int.Parse(d.Substring(0, 4));
                //截取具体某天
                int f = int.Parse(d.Substring(zz + 1, 2));
                int aa;
                aa = int.Parse(dataGridView1.Rows[i].Cells["Column8"].Value.ToString());//保质期
                                                                                        //辅助类方法调用
                bool result = OriderInfoClass.day(new DateTime(q, g, f), aa);
                if (result)
                {


                }
                else
                {
                    dataGridView1.Rows.Remove(dataGridView1.Rows[i]);
                    i--;

                }
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            //图片位置移动
            //pictureBox1.Location = new Point(pictureBox1.Location.X + 5, pictureBox1.Location.Y + 5);
            //模糊查询
            string sql = @"select i.*,t.GType from GoodsInfo i join GoodsType t
                        on i.GId = t.GId where 0=0";
            //把输入的值模糊查询出来
            if (textBox1.Text != "")
            {
                sql += $"and GInId like '%{textBox1.Text}%'";
            }
            if (textBox2.Text != "")
            {
                sql += $"and GName like '%{textBox2.Text}%'";
            }
            if (textBox3.Text != "")
            {
                sql += $"and i.GId like '%{textBox3.Text}%'";
            }
            //显示在网格视图中
            GetLook(sql);
            //100毫秒后图片回到当前位置
            //Thread.Sleep(100);
            //pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y - 5);
        }
    }
}
