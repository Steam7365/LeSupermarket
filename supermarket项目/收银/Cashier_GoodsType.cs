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
    public partial class Cashier_GoodsType : Form
    {
        public Cashier_GoodsType()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 将商品类型显示在视图表中
        /// </summary>
        /// <param name="sql">命令语句</param>
        public void GetLook()
        {
            //显示类型编号，商品类型，商品使用数量
            string sql = @"select t.GId,t.GType, count(i.GInId) as 数量 from GoodsType t left join GoodsInfo i
                            on t.GId = i.GId
                            group by t.GId,t.GType";
            //仓库
            DataSet dSet = new DataSet();
            //创建连接字符串
            using (SqlConnection con =new SqlConnection(DBHelper.connStr))
            {
                //货车
                SqlDataAdapter sda=new SqlDataAdapter(sql,con);
                //卸车
                sda.Fill(dSet);
                //显示数据
                dataGridView1.DataSource = dSet.Tables[0];
            }
        }
        private void Cashier_GoodsType_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(246, 246, 246);
            //dataGridView1.BackgroundColor = this.BackColor;
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            //将商品类型表显示在网格视图中
            GetLook();
            //赋值加载时的文本框内容
            this.text2 = textBox2.Text;
        }
        /// <summary>
        /// 流动当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();//关闭全部窗体
        }
        /// <summary>
        /// 判断关闭时是否关闭全部窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_GoodsType_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        /// <summary>
        /// 点击"添加"图片时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //点击后图片闪动
            pictureBox3.Location = new Point(pictureBox3.Location.X + 5, pictureBox3.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox3.Location = new Point(pictureBox3.Location.X - 5, pictureBox3.Location.Y - 5);
            //判断是否输入内容
            if (textBox3.Text=="")
            {
                return;
            }
            //添加商品
            string sql = $"insert into GoodsType values('{textBox3.Text}')";
            GetZSG(sql);
            //刷新
            GetLook();

            MessageBox.Show("添加成功！！");
            //重置
            textBox3.Text = "";
        }
        /// <summary>
        /// 商品表中的增删改
        /// </summary>
        /// <param name="sql">命令语句</param>
        public void GetZSG(string sql)
        {
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    int r = com.ExecuteNonQuery();
                }
            }
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //点击后图片闪动
            pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y - 5);

            //判断是否选中和修改的内容是否一致
            if (dataGridView1.SelectedRows.Count == 0|| this.text2 == textBox2.Text)
            {
                return;
            }
            //修改选中内容
            string sql = $"update GoodsType set Gtype='{textBox2.Text}' where GId='{textBox1.Text}'";
            GetZSG(sql);
            //刷新
            GetLook();
            MessageBox.Show("修改成功！！");
            //赋值改完后的内容
            this.text2 = textBox2.Text;

        }
        private string text2;//用来判断修改的内容是否一致
        /// <summary>
        /// 将选中内容显示在修改信息中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //判断是否选中
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            //赋值选中的内容在修改框中
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }
        /// <summary>
        /// 删除选中的列
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 删除此列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否删除此数据！！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dr==DialogResult.OK)
            {
                //删除选中的列
                string delete = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string sql = $"delete GoodsType where GId='{delete}'";
                GetZSG(sql);
                //刷新
                GetLook();
            }
        }
        /// <summary>
        /// 点击后text2等于选中的商品名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.text2 = textBox2.Text;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string tiaojin = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            GoodsTypeInfo gti = new GoodsTypeInfo(tiaojin);
            gti.ShowDialog();
        }
    }
}
