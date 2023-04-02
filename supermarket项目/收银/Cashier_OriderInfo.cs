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
    public partial class Cashier_OriderInfo : Form
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
        public Cashier_OriderInfo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 订单查询
        /// </summary>
        /// <param name="sql"></param>
        public void GetLookOrInfo(string sql)
        {
            DataSet dSet = new DataSet();
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql,con);
                sda.Fill(dSet);
                dataGridView1.DataSource = dSet.Tables[0];
            }
            //总账
            double yuanjia = 0;
            double youHui = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                yuanjia += double.Parse(dataGridView1.Rows[i].Cells["Column2"].Value.ToString());
                youHui += double.Parse(dataGridView1.Rows[i].Cells["Column3"].Value.ToString());
            }
            labSubtotal.Text= (yuanjia - youHui) + "元";
        }
        private void Cashier_OriderInfo_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(246, 246, 246);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            dataGridView1.AutoGenerateColumns = false;
            //显示订单总账数据
            string sql = "select * from OriderClose";
            GetLookOrInfo(sql);
            GetYear();
            skinComVip.Items.Add("是");
            skinComVip.Items.Add("否");
            skinComVip.Items.Add("");
        }
        
        public  void  GetYear()
        {
            skinComMonth.Enabled = false;
            skinComDay.Enabled = false;
            skinComYear.Items.Clear();
            for (int i = 2000; i <=DateTime.Now.Year; i++)
            {
                skinComYear.Items.Add(i+"年");
            }
        }
        string year;
        private void skinComYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            skinComMonth.Enabled = false;
            skinComDay.Enabled = false;
            skinComMonth.Items.Clear();
            skinComDay.Items.Clear();
            this.year = skinComYear.SelectedItem.ToString();
            this.year = year.Substring(0, 4);
            skinComMonth.Enabled = true;
            skinComMonth.Items.Clear();
            for (int i = 1; i <=12; i++)
            {
                skinComMonth.Items.Add(i.ToString("D2")+"月");
            }
            if (skinComDay.Enabled)
            {
                skinComMonth_SelectedIndexChanged(sender,e);
            }
        }
        private void skinComMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            skinComDay.Enabled = true;
            skinComDay.Items.Clear();
            switch (skinComMonth.Text)
            {
                case "01月":
                case "03月":
                case "05月":
                case "07月":
                case "08月":
                case "10月":
                case "12月":
                    for (int i = 1; i <=31; i++)
                    {
                        skinComDay.Items.Add(i.ToString("D2") + "日");
                    }
                    break;
                case "04月":
                case "06月":
                case "09月":
                case "11月":
                    for (int i = 1; i <=30; i++)
                    {
                        skinComDay.Items.Add(i.ToString("D2") + "日");
                    }
                    break;
                case "02月":
                    if (int.Parse(year)%4==0&&int.Parse(year)%100!=0||int.Parse(year)%400==0)
                    {
                        for (int i = 1; i <= 29; i++)
                        {
                            skinComDay.Items.Add(i.ToString("D2") + "日");
                        }
                    }
                    else
                    {
                        for (int i = 1; i <=28; i++)
                        {
                            skinComDay.Items.Add(i.ToString("D2") + "日");
                        }
                    }
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void Cashier_OriderInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void 查看详情ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("请选择你需要查看的信息！！","系统提示");
                return;
            }
            OriderInfoClass.OriderId = dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
            OriderInfo_Details orDetails = new OriderInfo_Details();
            orDetails.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pictureBox1_Click(sender, e);
        }

        private void 查看今日订单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = DateTime.Now.Day.ToString();
            string sql = $@"select * from OriderClose 
                        where SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{year}%'
                        and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{month}%'
                        and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{day}%'";

            GetLookOrInfo(sql);
        }

        private void 查看昨日订单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string day = (Convert.ToInt32(DateTime.Now.Day) - 1).ToString();
            string sql = $@"select * from OriderClose 
                        where SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{year}%'
                        and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{month}%'
                        and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{day}%'";

            GetLookOrInfo(sql);
        }

        private void 查看本月订单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.Year.ToString();
            string month = DateTime.Now.Month.ToString();
            string sql = $@"select * from OriderClose 
                        where SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{year}%'
                        and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{month}%'";

            GetLookOrInfo(sql);
        }

        private void 查看上月订单ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string year = DateTime.Now.Year.ToString();
            string month = (Convert.ToInt32(DateTime.Now.Month) - 1).ToString();
            string sql = $@"select * from OriderClose 
                        where SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{year}%'
                        and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{month}%'";

            GetLookOrInfo(sql);
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string sql = "select *,SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) from OriderClose where 0=0";
            if (skinComYear.Text != "")
            {
                int str = int.Parse(skinComYear.Text.Substring(0, 4));
                sql += $"and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{str}%'";
            }
            if (skinComMonth.Text != "")
            {
                int str = int.Parse(skinComMonth.Text.Substring(0, 2));
                sql += $"and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{str}%'";
            }
            if (skinComDay.Text != "")
            {
                int str = int.Parse(skinComDay.Text.Substring(0, 2));
                sql += $"and SUBSTRING(CAST(DealTime as varCHAR(50)),1,10) like '%{str}%'";
            }
            if (textBox2.Text != "")
            {
                sql += $"and uidname='{textBox2.Text}'";
            }
            if (skinComVip.Text != "")
            {
                sql += $"and OrWhether='{skinComVip.Text}'";
            }
            GetLookOrInfo(sql);
        }
    }
}
