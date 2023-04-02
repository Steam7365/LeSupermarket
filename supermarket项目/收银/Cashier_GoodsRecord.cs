using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supermarket项目
{
    public  partial  class Cashier_GoodsRecord : Form
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
        public Cashier_GoodsRecord()
        {
            InitializeComponent();
        }

        public void RecordInfo(string sql)
        {
            DataSet dSet = new DataSet();
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                sda.Fill(dSet);
                dataGridView1.DataSource = dSet.Tables[0];
            }
            //排行
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Cells["Column4"].Value = (i + 1).ToString();
            }
        }
        private void Cashier_GoodsRecord_Load(object sender, EventArgs e)
        {
            
        }
        /// <summary>
        /// label添值
        /// </summary>
        public void dateLab()
        {
            //获取近七日的时间
            label7.Text = DateTime.Now.AddDays(-1).ToShortDateString() + ":";//昨天
            label8.Text = DateTime.Now.AddDays(-2).ToShortDateString() + ":";//前台
            label9.Text = DateTime.Now.AddDays(-3).ToShortDateString() + ":";
            label10.Text = DateTime.Now.AddDays(-4).ToShortDateString() + ":";
            label11.Text = DateTime.Now.AddDays(-5).ToShortDateString() + ":";
            label12.Text = DateTime.Now.AddDays(-6).ToShortDateString() + ":";
            label13.Text = DateTime.Now.AddDays(-7).ToShortDateString() + ":";

            //获取七日内的每个价格
            string sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 1";
            label14.Text = "￥" + time(sql, label14.Text);//昨天

            sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 2";
            label15.Text = "￥" + time(sql, label15.Text);//前天

            sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 3";
            label16.Text = "￥" + time(sql, label16.Text);//大前天

            sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 4";
            label17.Text = "￥" + time(sql, label17.Text);//前4天

            sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 5";
            label18.Text = "￥" + time(sql, label18.Text);//前5天

            sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 6";
            label19.Text = "￥" + time(sql, label19.Text);//前6天

            sql = @"select sum(MustPrice+ActualPrice) from OriderClose
                        where DateDiff(dd, DealTime, getdate())= 7";
            label20.Text = "￥" + time(sql, label20.Text);//前7天
        }
        /// <summary>
        /// 获取近七天的小计
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private string time(string sql, string text)
        {
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    text = com.ExecuteScalar().ToString() + "元";
                    if (text == "元")
                    {
                        text = "0元";
                    }
                }
            }
            return text;
        }

        /// <summary>
        /// SkinPanel长度
        /// </summary>
        public void longPanel()
        {
            double[] lab = new double[7];
            lab[0] = Number(label14.Text);
            lab[1] = Number(label15.Text);
            lab[2] = Number(label16.Text);
            lab[3] = Number(label17.Text);
            lab[4] = Number(label18.Text);
            lab[5] = Number(label19.Text);
            lab[6] = Number(label20.Text);
            Panel[] pan = new Panel[7] { skinPanel1, skinPanel2, skinPanel3, skinPanel4, skinPanel5, skinPanel6, skinPanel7 };
            for (int i = 0; i < lab.Length; i++)
            {
                if (lab[i]*0.01<1&&lab[i]!=0)
                {
                    pan[i].Width += 3;
                }
                else
                {
                    pan[i].Width += (int)(lab[i] * 0.008);
                }
            }
            skinPanel1.Width = pan[0].Width;
            skinPanel2.Width = pan[1].Width;
            skinPanel3.Width = pan[2].Width;
            skinPanel4.Width = pan[3].Width;
            skinPanel5.Width = pan[4].Width;
            skinPanel6.Width = pan[5].Width;
            skinPanel7.Width = pan[6].Width;
        }
        public double Number(string labstr)
        {
            //获取价格
            char[] ch = { '￥', '元' };
            string[] str = labstr.Split(ch, StringSplitOptions.RemoveEmptyEntries);
            string lab = "";
            for (int i = 0; i < str.Length; i++)
            {
                lab += str[i];
            }
            return double.Parse(lab);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;//不自动生成列
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;//不显示网格线
            dataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//内容数据居中
            string sql = @"select GInId,GName,GetCount from GoodsInfo
                            order by GetCount desc";
            RecordInfo(sql);
            dateLab();
            longPanel();

            dataGridView1.Rows[0].Cells[0].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold);
            dataGridView1.Rows[0].Cells[1].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold);
            dataGridView1.Rows[0].Cells[2].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold);
            dataGridView1.Rows[0].Cells[3].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold);

            dataGridView1.Rows[1].Cells[0].Style.Font = new Font("微软雅黑", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.Rows[1].Cells[1].Style.Font = new Font("微软雅黑", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.Rows[1].Cells[2].Style.Font = new Font("微软雅黑", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.Rows[1].Cells[3].Style.Font = new Font("微软雅黑", 14, FontStyle.Bold, GraphicsUnit.Pixel);

            dataGridView1.Rows[2].Cells[0].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.Rows[2].Cells[1].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.Rows[2].Cells[2].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold, GraphicsUnit.Pixel);
            dataGridView1.Rows[2].Cells[3].Style.Font = new Font("微软雅黑", 13, FontStyle.Bold, GraphicsUnit.Pixel);

            dataGridView1.Rows[0].Selected = false;//加载时不选中
            timer1.Enabled = false;
        }
    }
}
