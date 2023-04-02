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
    public partial class FrmGoodsInfoAdd : Form
    {
        public FrmGoodsInfoAdd()
        {
            InitializeComponent();
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
        private void FrmGoodsInfoAdd_Load(object sender, EventArgs e)
        {
            ShowTime();//设置状态栏
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
        /// 添加商品
        /// </summary>
        /// <param name="sql">命令语句</param>
        public void Add(string sql)
        {
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
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
                        new SqlParameter("@factory",textBox9.Text)//厂家
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
                        b = false;//保存改为添加失败
                    }
                    
                }
            }
        }
        /// <summary>
        /// 流动状态栏当前时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            staLabel2.Text = "当前时间：" + DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        bool b = true;//用来判断是否添加成功
        /// <summary>
        /// 点击返回图片关闭当前窗体
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
            //关闭窗体
            this.Close();
        }
        /// <summary>
        /// 点击添加图片将信息添加到数据库中并显示在视图中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox3.Location = new Point(pictureBox3.Location.X + 5, pictureBox3.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox3.Location = new Point(pictureBox3.Location.X - 5, pictureBox3.Location.Y - 5);
            //添加命令语句
            string sql = @"insert into GoodsInfo 
                        values(@name,@specs,@price,@disprice,@count,@time,@protect,@factory,@Gid,0)";
            Add(sql);
            //判断是否添加成功
            if (b == false)
            {
                //若添加不成功提示并不重置信息
                b = true;
                MessageBox.Show("请输入正确的信息！！");
                return;
            }
            //刷新视图
            DBHelper.GoodsInfo.GetLook("select * from GoodsInfo");
            //添加成功后重置
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        /// <summary>
        /// 按Enter键时触发点击添加图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox3_Click_1(sender, e);
        }
        /// <summary>
        /// 按Esc键时触发点击返回图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click_1(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }
    }
}
