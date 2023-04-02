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
    public partial class Cashier_Boss : Form
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
        public Cashier_Boss()
        {
            InitializeComponent();
        }
        #region 鼠标移动与离开
        public new  void MouseMove(Panel p1,PictureBox p2,Label lab,int r,int g,int y)
        {
            p1.BackColor = Color.FromArgb(r,g,y);
            lab.BackColor = Color.FromArgb(r, g, y);
            p2.BackColor = Color.FromArgb(r, g, y);
            if (b)
            {
                p1.Size = new Size(p1.Size.Width + 5, p1.Size.Height + 5);
                lab.Size = new Size(lab.Size.Width + 5, lab.Size.Height + 5);
                p2.Size = new Size(p2.Size.Width + 5, p2.Size.Height + 5);

                b = false;
            }
        }
        public new  void MouseLeave(Panel p1, PictureBox p2, Label lab, int r, int g, int y)
        {
            p1.BackColor = Color.FromArgb(r, g, y);
            lab.BackColor = Color.FromArgb(r, g, y);
            p2.BackColor = Color.FromArgb(r, g, y);

            p1.Size = new Size(p1.Size.Width - 5, p1.Size.Height - 5);
            p2.Size = new Size(p2.Size.Width - 5, p2.Size.Height - 5);
            b = true;
        }
        bool b = true;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //Color.FromArgb(145, 114, 244);
            MouseMove(panel1, pictureBox2, label1, 155, 124, 254);
        }
        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel1, pictureBox2,label1, 145, 114, 224);
        }

        private void pictureBox2_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel1, pictureBox2, label1, 155, 124, 254);
        }
        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel1, pictureBox2, label1, 145, 114, 224);
        }


        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            //255, 229, 31
            MouseMove(panel2, pictureBox4, label2, 255, 239, 41);
        }
        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel2, pictureBox4, label2, 255, 229, 31);
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel2, pictureBox4, label2, 255, 239, 41);
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel2, pictureBox4, label2, 255, 229, 31);
        }


        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel3, pictureBox14, label3, 251, 107, 133);
        }

        private void panel3_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel3, pictureBox14, label3, 251, 97, 123);
        }

        private void pictureBox14_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel3, pictureBox14, label3, 251, 107, 133);
        }

        private void pictureBox14_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel3, pictureBox14, label3, 251, 97, 123);
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            //145, 114, 244
            MouseMove(panel4, pictureBox8, label4, 155, 124, 254);
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel4, pictureBox8, label4, 145, 114, 244);
        }

        private void pictureBox8_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel4, pictureBox8, label4, 155, 124, 254);
        }

        private void pictureBox8_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel4, pictureBox8, label4, 155, 124, 254);
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel5, pictureBox10, label5, 251, 97, 123);
        }

        private void panel5_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel5, pictureBox10, label5, 251, 107, 133);
        }

        private void pictureBox10_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel5, pictureBox10, label5, 251, 107, 133);
        }

        private void pictureBox10_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel5, pictureBox10, label5, 251, 97, 123);
        }

        private void panel6_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel6, pictureBox12, label6, 255, 239, 41);
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel6, pictureBox12, label6, 255, 229, 31);
        }

        private void pictureBox12_MouseMove(object sender, MouseEventArgs e)
        {
            MouseMove(panel6, pictureBox12, label6, 255, 239, 41);
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            MouseLeave(panel6, pictureBox12, label6, 255, 239, 41);
        }
        #endregion

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_Boss_Load(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString();
        }
        /// <summary>
        /// 流动时间
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            labTime.Text = DateTime.Now.ToString();
        }

        bool close = true;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.close = false;
            ForYuanG fyg = new ForYuanG();
            fyg.zhanh = Chanzhi.zhan;
            fyg.Show();
            this.Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("是否退出系统！！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //若点击取消就取消关闭事件
            if (dr == DialogResult.OK)
            {
                Chanzhi.uidOrPwd.Close();
            }
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Chanzhi.Bo = true;
            this.close = false;
            this.Close();
            Cashier_Main Cashier = new Cashier_Main();
            Cashier.Show();
        }
        
        private void pictureBox14_Click(object sender, EventArgs e)
        {
            Chanzhi.Bo = false;
            this.close = false;
            this.Close();
            Cashier_Main Cashier = new Cashier_Main();
            Cashier.Show();
        }

        private void Cashier_Boss_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close)
            {
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
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.close = false;
            窗体设置测试 QianTai = new 窗体设置测试();
            QianTai.Show();
            this.Close();
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
