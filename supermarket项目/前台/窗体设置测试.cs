using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supermarket项目
{
    public partial class 窗体设置测试 : Form
    {
        public 窗体设置测试()
        {
            InitializeComponent();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void 窗体设置测试_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            pictureBox9_Click(sender, e);
            labUid.Text= Chanzhi.zhan;
            labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (!Chanzhi.gly)
            {
                pictureBox11.Enabled = false;
                pictureBox6.Enabled = false;
                label7.Enabled = false;
            }
        }
        public new void MouseMove(PictureBox p1, PictureBox p2, Label lab)
        {
            p1.BackColor = Color.FromArgb(52, 69, 97);
            lab.BackColor = p1.BackColor;
            p2.BackColor = Color.FromArgb(52, 69, 97);
        }
        public new  void MouseLeave(PictureBox p1, PictureBox p2,Label lab)
        {
            p1.BackColor = Color.FromArgb(72, 89, 117);
            p2.BackColor = Color.FromArgb(72, 89, 117);
            lab.BackColor = p1.BackColor;
        }
        //#region 移动与离开到首页时

        //private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    MouseMove(pictureBox1, pictureBox7,label1);
        //}

        //private void pictureBox1_MouseLeave(object sender, EventArgs e)
        //{
        //    MouseLeave(pictureBox1, pictureBox7, label1);
        //}
        //#endregion

        #region 移动与离开"会员详情"时
        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(pictureBox2, pictureBox8, label2);
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(pictureBox2, pictureBox8, label2);
        }
        #endregion

        #region 移动与离开”礼品信息“时
        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(pictureBox3, pictureBox9, label3);
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(pictureBox3, pictureBox9, label3);
        }
        #endregion

        #region 移动与离开“兑换详情”时
        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(pictureBox4, pictureBox10, label4);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(pictureBox4, pictureBox10, label4);
        }
        #endregion

        #region 移动与离开“挂机”时
        private void pictureBox5_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(pictureBox5, pictureBox12, label6);
        }

        private void pictureBox5_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(pictureBox5, pictureBox12, label6);
        }


        #endregion

        #region 移动与离开”管理员“时
        private void pictureBox6_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(pictureBox6, pictureBox11, label7);
        }

        private void pictureBox6_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(pictureBox6, pictureBox11, label7);
        }
        #endregion

        #region 移动与离开“退出”时
        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(pictureBox14, pictureBox13, label5);
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(pictureBox14, pictureBox13, label5);
        }
        #endregion

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        /// <summary>
        /// 点击会员详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
            //DBHelper.Cmain = this;//把当前窗体传值过去
            VipInfo Vip = new VipInfo();
            Vip.MdiParent = this;
            Vip.Dock = DockStyle.Fill;
            Vip.Show();
        }
        /// <summary>
        /// 会员详情
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            ActiveMdiChild.Close();
            //DBHelper.Cmain = this;//把当前窗体传值过去
            GiftChangeInfo giftChange = new GiftChangeInfo();
            giftChange.MdiParent = this;
            giftChange.Dock = DockStyle.Fill;
            giftChange.Show();
        }
        bool b = false;

        /// <summary>
        /// 礼品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (b)
            {
                ActiveMdiChild.Close();
            }
            //DBHelper.Cmain = this;//把当前窗体传值过去
            MainFrom gift = new MainFrom();
            gift.MdiParent = this;
            gift.Dock = DockStyle.Fill;
            gift.Show();
            b = true;
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        bool close = false;
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Cashier_Boss boss = new Cashier_Boss();
            boss.Show();
            close = true;
            this.Close();
            close = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 窗体设置测试_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.close)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("是否退出系统！！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //若点击取消就取消关闭事件
            if (dr != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                Chanzhi.uidOrPwd.Close();
            }
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            Chanzhi.frm = this;
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
