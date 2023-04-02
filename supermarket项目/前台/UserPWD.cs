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
    public partial class UserPWD : Form
    {
        public UserPWD()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                return;
            }
            Class1.pwd = this.textBox1.Text;
            this.Close();
            Hang_up a = new Hang_up();
            a.Show();
        }
    }
}
