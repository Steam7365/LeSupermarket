using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 超市管理
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.label2.Text = "";
            this.label4.Text = DateTime.Now.ToShortDateString();
            this.label1.Text = DateTime.Now.ToString(" hh:mm:ss");
            this.timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            this.label4.Text = DateTime.Now.ToShortDateString();
            this.label1.Text = DateTime.Now.ToString(" hh:mm:ss");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "010101")
            {
                Application.Exit();
            }
        }

        private void Form2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            this.Opacity = 40;
        }
    }
}
