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
    public partial class FrmGoodsInfoAlter : Form
    {
        public FrmGoodsInfoAlter()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 将选中的商品信息显示在各个文本框中
        /// </summary>
        /// <param name="sql"></param>
        public void GetLook()
        {
            textBox10.Text = DBHelper.dgv.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = DBHelper.dgv.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = DBHelper.dgv.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = DBHelper.dgv.SelectedRows[0].Cells[3].Value.ToString();
            textBox4.Text = DBHelper.dgv.SelectedRows[0].Cells[4].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(DBHelper.dgv.SelectedRows[0].Cells[6].Value);
            textBox5.Text = DBHelper.dgv.SelectedRows[0].Cells[5].Value.ToString();
            textBox7.Text = DBHelper.dgv.SelectedRows[0].Cells[7].Value.ToString();
            textBox9.Text = DBHelper.dgv.SelectedRows[0].Cells[8].Value.ToString();
            textBox8.Text = DBHelper.dgv.SelectedRows[0].Cells[9].Value.ToString();
        }
        /// <summary>
        /// 设置状态栏
        /// </summary>
        public void ShowTime()
        {
            //设置登录时间和当前时间
            staLabel1.Text += DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            staLabel2.Text += DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            //toolStrip1.BackColor = Color.FromArgb(217, 210, 200);
            //修改状态栏的颜色
            statusStrip1.BackColor = Color.FromArgb(217, 210, 244);
            //设置当前时间的位置在最右
            int x = this.ClientSize.Width - staLabel2.Width - staLabel1.Width - 20;
            staLabel2.Margin = new Padding(x, 0, 0, 0);
        }
        private void FrmGoodsInfoAlter_Load(object sender, EventArgs e)
        {
            ShowTime();//设置状态栏
            GetLook();//显示视图数据再文本框中
            textBox10.Enabled = false;//不可修改商品信息
            //tab索引顺序
            textBox1.TabIndex = 0;
            textBox2.TabIndex = 1;
            textBox3.TabIndex = 2;
            textBox4.TabIndex = 3;
            textBox5.TabIndex = 4;
            dateTimePicker1.TabIndex = 5;
            textBox7.TabIndex = 6;
            textBox8.TabIndex = 7;
            textBox9.TabIndex = 8;
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="sql">命令语句</param>
        public void Add(string sql)
        {
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.AddRange(new SqlParameter[]
                    {
                        new SqlParameter("@name",textBox1.Text),//名称
                        new SqlParameter("@specs",textBox2.Text),//规格
                        new SqlParameter("@price",textBox3.Text),//单价
                        new SqlParameter("@disprice",textBox4.Text),//折扣价
                        new SqlParameter("@count",textBox5.Text),//数量
                        new SqlParameter("@time",dateTimePicker1.Text),//生产日期
                        new SqlParameter("@protect",textBox7.Text),//保质期
                        new SqlParameter("@Gid",textBox8.Text),//类型编号
                        new SqlParameter("@factory",textBox9.Text),//厂家
                        new SqlParameter("@GInId",textBox10.Text)//信息编号
                    });
                    try
                    {
                        int r = com.ExecuteNonQuery();
                        if (r != 0)
                        {
                            MessageBox.Show("添加成功！！");
                        }
                    }
                    catch
                    {
                        MessageBox.Show("修改失败！！");
                    }
                }
            }
        }
        /// <summary>
        /// 点击修改图片触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox3.Location = new Point(pictureBox3.Location.X + 5, pictureBox3.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox3.Location = new Point(pictureBox3.Location.X - 5, pictureBox3.Location.Y - 5);
            //修改信息
            string sql = @"update GoodsInfo 
                        set Gname=@name,GSpecs=@specs,GPrice=@price,DisPrice=@disprice,GCount=@count,GTime=@time,GProtect=@protect,GFactory=@factory,GId=@Gid
                        where GInId=@GInId";
            Add(sql);
            //刷新视图数据
            DBHelper.GoodsInfo.GetLook("select * from GoodsInfo");
            this.Close();
        }
        /// <summary>
        /// 点击返回图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y - 5);
            Thread.Sleep(100);
            //关闭当前窗体
            this.Close();
        }
        /// <summary>
        /// 按Enter时触发点击修改图片时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender, e);
        }
        /// <summary>
        /// 按Esc是触发点击返回图片事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }
        /// <summary>
        /// 流动状态栏的当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            staLabel2.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
        }
    }
}
