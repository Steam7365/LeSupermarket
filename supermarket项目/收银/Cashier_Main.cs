using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace supermarket项目
{
    public partial class Cashier_Main : Form
    {
        public Cashier_Main()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 加载时显示时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_Main_Load(object sender, EventArgs e)
        {
            strShouYan_Click(sender, e);
            if (Chanzhi.Bo)
            {
                toolStripButton5.Visible = false;
                StrDingDang.Visible = false;
                strGoods.Visible = false;
                toolStripButton3.Visible = false;
            }
            else
            {
                strShouYan.Visible = false;
                toolStripButton5_Click(sender, e);
            }
            if (!Chanzhi.gly)
            {
                strGuanLiyu.Visible = false;
            }
            ShowTime();
            DBHelper.Cmain = this;
            
            toolStrUid.Text = Chanzhi.zhan;
        }
        public  void  ShowTime()
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
        /// <summary>
        /// 当前时间会流动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            //每过一秒获取当前时间
            staLabel2.Text = "当前时间："+DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
        }

        /// <summary>
        ///当窗体发送改变时，当前时间位置保持不变 
        /// </summary>
        private void Cashier_Main_LocationChanged(object sender, EventArgs e)
        {
            int x = this.ClientSize.Width - staLabel2.Width - staLabel1.Width - 20;
            staLabel2.Margin = new Padding(x, 0, 0, 0);
        }

        bool close = false;
        /// <summary>
        /// 打开管理员系统窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strGuanLiyu_Click(object sender, EventArgs e)
        {
            Cashier_Boss boss = new Cashier_Boss();
            boss.Show();
            close = true;
            this.Close();
        }

        /// <summary>
        /// 点击关闭图标，关闭所有窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 退出时判断是否退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
                return;
            }
            DialogResult dr= MessageBox.Show("是否退出系统！！","系统提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
            //若点击取消就取消关闭事件
            if (dr!=DialogResult.OK)
            {
                e.Cancel=true;
            }
            else
            {
                Chanzhi.uidOrPwd.Close();
            }
        }
        /// <summary>
        /// 打开商品信息窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strGoods_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
            DBHelper.Cmain = this;//把当前窗体传值过去
            Cashier_GoodsInfo GoodsInfo = new Cashier_GoodsInfo();
            GoodsInfo.MdiParent = this;
            GoodsInfo.Dock = DockStyle.Fill;
            GoodsInfo.Show();
        }
        /// <summary>
        /// 打开商品类型页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
            DBHelper.Cmain = this;//把当前窗体传值过去
            Cashier_GoodsType GoodsType = new Cashier_GoodsType();
            GoodsType.MdiParent = this;
            GoodsType.Dock = DockStyle.Fill;
            GoodsType.Show();
        }

        bool b = false;//判断关闭子窗体时是否为空
        /// <summary>
        /// 打开收银结账页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void strShouYan_Click(object sender, EventArgs e)
        {
            if (b)
            {
                ActiveMdiChild.Close();
            }
            b = true;
            DBHelper.Cmain = this;//把当前窗体传值过去
            Cashier_OriderClose OriderClose = new Cashier_OriderClose();
            OriderClose.MdiParent = this;//设置为子窗体
            OriderClose.Dock = DockStyle.Fill;//显示时填充大小
            OriderClose.Show();
        }
        public void Jiezhang(object sender, EventArgs e)
        {
            strShouYan_Click( sender,  e);
        }
        /// <summary>
        /// 打开订单信息页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StrDingDang_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
            DBHelper.Cmain = this;//把当前窗体传值过去
            Cashier_OriderInfo OriderInfo = new Cashier_OriderInfo();
            OriderInfo.MdiParent = this;
            OriderInfo.Dock = DockStyle.Fill;
            OriderInfo.Show();
        }
        /// <summary>
        /// 挂机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Chanzhi.frm = this;
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
            DBHelper.Cmain = this;//把当前窗体传值过去
            Cashier_GoodsRecord record = new  Cashier_GoodsRecord();
            record.MdiParent = this;
            record.Dock = DockStyle.Fill;
            record.Show();
        }
    }
}
