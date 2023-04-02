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
    public partial class Hang_up : Form
    {
        public Hang_up()
        {
            InitializeComponent();
        }

        private void Hang_up_Load(object sender, EventArgs e)
        {
            timer1.Start();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                this.textBox1.BackColor = Color.Red;
                return;

            }
            if (textBox1.Text==Class1.pwd)
            {
                this.Close();
            }
            else
            {
                this.textBox1.BackColor = Color.Red;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        
    }
}
