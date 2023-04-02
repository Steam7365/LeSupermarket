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
    public partial class OriderInfo : Form
    {
        public OriderInfo()
        {
            InitializeComponent();
        }
        string date;//交易时间
        string orid;//订单号

        string GoodsId;//商品编号  1
        string GoodsName;//商品名称 2
        string YuanJia;//原价 4
        string DisPrice;//折后价 5
        string GMCount;//购买数量 6

        /// <summary>
        /// 获取订单号
        /// </summary>
        public void OriderId()
        {
            string sql = $"select OrId from OriderClose where DealTime='{date}'";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    this.orid = ((int)com.ExecuteScalar()).ToString();
                }
            }
        }
        /// <summary>
        /// 给订单总账单添加数据
        /// </summary>
        public void OriderAdd()
        {
            date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//交易时间
            string str = "";//是否会员
            if (OriderInfoClass.RaDioYes.Checked)
            {
                str = "是";
            }
            else
            {
                str = "否";
            }
            //添加语句
            string sql;
            if (str == "否")
            {
                sql = $@"insert into OriderClose
                         values(@OrWhether,null,@MustPrice,@ActualPrice,@Amass,@UidName,@DealTime)";
            }
            else
            {
                sql = $@"insert into OriderClose
                         values(@OrWhether,@OrMemberID,@MustPrice,@ActualPrice,@Amass,@UidName,@DealTime)";
            }
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    try
                    {
                        con.Open();
                        com.Parameters.AddRange(new SqlParameter[]
                        {
                        new SqlParameter("@OrWhether",str),//是否会员
                        new SqlParameter("@OrMemberID",OriderInfoClass.textVip.Text),//会员号
                        new SqlParameter("@MustPrice",OriderInfoClass.textPrice.Text),//原价
                        new SqlParameter("@ActualPrice",OriderInfoClass.textDisPrice.Text),//优惠
                        new SqlParameter("@Amass",OriderInfoClass.textJiFen.Text),//积分
                        new SqlParameter("@UidName",Chanzhi.BID),//操作员
                        new SqlParameter("@DealTime",date),//交易时间
                        });
                        int r = com.ExecuteNonQuery();
                    }
                    catch
                    {
                    }
                }
            }
        }
        /// <summary>
        /// 给订单信息表添加数据
        /// </summary>
        public void OriderInfoAdd()
        {
            OriderId();//获取订单号
            //将购买的商品依次添加到信息表
            for (int i = 0; i < OriderInfoClass.dgv.Rows.Count; i++)
            {
                
                //若购买数量不为0
                if (int.Parse(OriderInfoClass.dgv.Rows[i].Cells["Column6"].Value.ToString()) != 0)
                {
                    this.GoodsId = OriderInfoClass.dgv.Rows[i].Cells["Column1"].Value.ToString();//商品编号
                    this.GoodsName = OriderInfoClass.dgv.Rows[i].Cells["Column2"].Value.ToString();//商品名称
                    this.YuanJia = OriderInfoClass.dgv.Rows[i].Cells["Column4"].Value.ToString();//商品原价
                    this.DisPrice = OriderInfoClass.dgv.Rows[i].Cells["Column5"].Value.ToString();//商品折后价
                    this.GMCount = OriderInfoClass.dgv.Rows[i].Cells["Column6"].Value.ToString();//购买数量
                    //添加语句
                    string sql = @"insert into OriderInfo
                        values(@OrId,@GInId,@GName,@Price,@OrInCount,@Discount,@Subtotal)";
                    //添加购买了的商品信息
                    using (SqlConnection con = new SqlConnection(DBHelper.connStr))
                    {
                        con.Open();
                        using (SqlCommand com = new SqlCommand(sql, con))
                        {
                            com.Parameters.AddRange(new SqlParameter[]
                            {
                                new SqlParameter("@OrId",orid),//订单号
                                new SqlParameter("@GInId",GoodsId),//商品编号
                                new SqlParameter("@GName",GoodsName),//商品名称
                                new SqlParameter("@Price",YuanJia),//原价
                                new SqlParameter("@OrInCount",GMCount),//购买数量
                                new SqlParameter("@Discount",DisPrice),//折后价
                                new SqlParameter("@Subtotal",OriderInfoClass.labXiaoJi.Text),//小计
                            });
                            int r = com.ExecuteNonQuery();
                            if (r == 0)
                            {
                                MessageBox.Show("Test");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 显示订单信息表信息  
        /// </summary>
        public void Orider()
        {
            string sql = $"select GName,Price,OrInCount,Discount from OriderInfo where orid='{orid}'";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader sr = com.ExecuteReader())
                    {
                        //显示订单号一致的所有订单信息
                        while (sr.Read())
                        {
                            listBox1.Items.Add("商品名称：   " + sr[0] + "         \t" + string.Format(sr[1].ToString(), "F2") + "*" + sr[2]);
                            listBox1.Items.Add("折后价：      " + sr[0] + "         \t" + sr[3] + "*" + sr[2]);
                            //将商品名称相同的商品数量修改
                            for (int i = 0; i < Gname.Count; i++)
                            {
                                if (sr[0].ToString() == Gname[i])
                                {
                                    if (int.Parse(Gcount[i]) - Convert.ToInt32(sr[2].ToString())<0)
                                    {
                                        buer = 1;
                                        MessageBox.Show(Gname[i]+"数量不足");
                                    }
                                    Gcount[i] = (int.Parse(Gcount[i]) - Convert.ToInt32(sr[2].ToString())).ToString();
                                    Bname.Add(Gname[i]);
                                    bCount.Add(Gcount[i]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 显示订单总账表信息
        /// </summary>
        public void OriderZZ()
        {
            string sql = $@"select MustPrice,ActualPrice,OrWhether,OrMemberID,Amass,DealTime
                          from OriderClose
                          where orid='{orid}'";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader sr = com.ExecuteReader())
                    {
                        while (sr.Read())
                        {
                            listBox1.Items.Add("原价：         \t" + sr[0]);
                            listBox1.Items.Add("优惠：         \t" + sr[1]);
                            listBox1.Items.Add("是否会员：         \t" + sr[2]);
                            listBox1.Items.Add("会员号：         \t" + sr[3]);
                            listBox1.Items.Add("积分：         \t" + sr[4]);
                        }
                    }
                }
            }
        }
        List<string> Gname = new List<string>();//所有商品名称的集合
        List<string> Gcount = new List<string>();//所有商品数量的集合

        List<string> Bname = new List<string>();//购买的商品名称集合
        List<string> bCount = new List<string>();//购买的商品数量集合
        int buer = 0;
        /// <summary>
        /// 获取商品信息的所有商品的数量与商品名称
        /// </summary>
        public void GoodsCount()
        {
            string sql = "select gname, Gcount from GoodsInfo";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    con.Open();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            Gname.Add(sdr[0].ToString());
                            Gcount.Add(sdr[1].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 将修改后的商品数量存入数据库中
        /// </summary>
        public void InsertDBSS()
        {
            for (int i = 0; i < Bname.Count; i++)
            {
                string sql = $@"update  GoodsInfo  
                               set Gcount='{bCount[i]}'
                               where Gname='{Bname[i]}'";
                using (SqlConnection con = new SqlConnection(DBHelper.connStr))
                {
                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        try
                        {
                            con.Open();
                            com.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                    }
                }
            }

        }
        /// <summary>
        /// 将购买的数量增加到商品使用数量中
        /// </summary>
        public void GetGoodsCount()
        {
            for (int i = 0; i < Bname.Count; i++)
            {
                string sql = $@"select GCount from GoodsInfo
                               where Gname='{Bname[i]}'";
                string getGCount = "";
                //先获取原来的商品数量
                using (SqlConnection con=new SqlConnection(DBHelper.connStr))
                {
                    con.Open();
                    using (SqlCommand com=new SqlCommand(sql,con))
                    {
                        getGCount = com.ExecuteScalar().ToString();
                    }
                }
                //获取购买数量
                getGCount = (int.Parse(getGCount) - int.Parse(bCount[i])).ToString();

                string str = $@"update  GoodsInfo  
                            set GetCount+=@Getcount
                            where Gname=@Gname";
                using (SqlConnection con = new SqlConnection(DBHelper.connStr))
                {
                    con.Open();
                    using (SqlCommand command = new SqlCommand(str, con))
                    {
                        command.Parameters.AddRange(new SqlParameter[]
                        {
                           new SqlParameter("@Getcount",int.Parse(getGCount)),
                           new SqlParameter("@Gname",Bname[i]),
                        });
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OriderInfo_Load(object sender, EventArgs e)
        {
            GoodsCount();//获取所有商品信息
            OriderAdd();
            OriderInfoAdd();
            label1.Text += orid;

            Orider();
            listBox1.Items.Add("==========================================");
            OriderZZ();
            label2.Text += OriderInfoClass.labXiaoJi.Text;
            if (buer == 1)
            {
                pictureBox3_Click(sender, e);
            }
        }



        /// <summary>
        /// 按Esc键触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            //触发返回图片点击事件
            pictureBox3_Click(sender, e);
        }
        /// <summary>
        /// 按回车键触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            //触发ok图片点击事件
            pictureBox1_Click(sender, e);
        }


        /// <summary>
        /// 点击图片关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox1.Location = new Point(pictureBox1.Location.X + 5, pictureBox1.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y - 5);
            Thread.Sleep(100);

            GetGoodsCount();

            InsertDBSS();
            MessageBox.Show("购物成功！！");
            Class1.JieZhang = true;
            //关闭窗口
            this.Close();
        }
        /// <summary>
        /// 点击图片删除订单表数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox3.Location = new Point(pictureBox3.Location.X + 5, pictureBox3.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox3.Location = new Point(pictureBox3.Location.X - 5, pictureBox3.Location.Y - 5);
            //删除数据库内容
            string sql = $"delete OriderClose where orid='{orid}'";
            string sql2 = $"delete OriderInfo where orid='{orid}'";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                //删除订单信息表
                using (SqlCommand com = new SqlCommand(sql2, con))
                {
                    com.ExecuteNonQuery();
                }
                //删除订单总账表
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.ExecuteNonQuery();
                }
            }
            Class1.JieZhang = false;
            //返回创建
            this.Close();
        }
    }
}
