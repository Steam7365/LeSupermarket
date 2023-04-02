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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label2.Text = Chanzhi.zhan;
            this.label4.Text = DateTime.Now.ToShortDateString();
            this.label1.Text = DateTime.Now.ToString(" hh:mm:ss");
            this.timer1.Start();
            this.button1.Enabled = false;
            b = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.label4.Text = DateTime.Now.ToShortDateString();
            this.label1.Text = DateTime.Now.ToString(" hh:mm:ss");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
        bool b = false;
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
        private void Form2_Click(object sender, EventArgs e)
        {
            if (b)
            {
                panel3.Visible = true;
                label1.Visible = false;
                label4.Visible = false;
                this.BackgroundImage = Image.FromFile("timg (3).jpg");
                button1.Enabled = true;
                b = false;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Chanzhi.uidOrPwd.Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            pictureBox12.Location = new Point(pictureBox12.Location.X + 3, pictureBox12.Location.Y + 3);
            Thread.Sleep(100);
            pictureBox12.Location = new Point(pictureBox12.Location.X - 3, pictureBox12.Location.Y - 3);
            if (textBox1.Text == Chanzhi.pwd)
            {
                Chanzhi.frm.Show();
                this.Close();
                notifyIcon1.Visible = false;
            }
            else
            {
                MessageBox.Show("输入密码错误！！");
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox12_Click(sender, e);
        }
    }
}
