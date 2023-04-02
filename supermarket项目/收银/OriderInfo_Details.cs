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
    public partial class OriderInfo_Details : Form
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
        public OriderInfo_Details()
        {
            InitializeComponent();
        }
        public void GetInfo()
        {
            string sql = $"select *from OriderInfo where orid='{OriderInfoClass.OriderId}'";
            DataSet dSet = new DataSet();
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql,con);
                sda.Fill(dSet);
                dataGridView1.DataSource = dSet.Tables[0];
            }
        }
        /// <summary>
        /// 状态栏与控件背景色
        /// </summary>
        public void ShowTime()
        {
            //设置登录时间和当前时间
            staLabel1.Text += DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
            staLabel2.Text += DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");

            //设置当前时间的位置在最右
            int x = this.ClientSize.Width - staLabel2.Width - staLabel1.Width - 20;
            staLabel2.Margin = new Padding(x, 0, 0, 0);
            this.BackColor = Color.FromArgb(246, 246, 246);//窗体背景色
            statusStrip1.BackColor = Color.FromArgb(217, 210, 200);//修改状态栏的颜色

        }
        private void OriderInfo_Details_Load(object sender, EventArgs e)
        {
            ShowTime();
            GetInfo();
            label2.Text += dataGridView1.Rows[0].Cells["Column8"].Value.ToString();
            //dataGridView1.BackgroundColor = this.BackColor;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
