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
    public partial class VIPCart : Form
    {
        public VIPCart(string a,string b)
        {
            number = b;
            name = a;
            InitializeComponent();
        }
        public string number, name, san, wei, xi, min;

        private void skinButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public string si = "****";
        public string to = "*";
        public string toto = "**";
        private void VIPCart_Load(object sender, EventArgs e)
        {

            san = number.Substring(0, 3);
            wei = number.Substring(7, 4);
            label3.Text += san + si + wei;
            xi = name.Substring(0, 1);
            int zz = name.Length - 1;
            min = name.Substring(zz, 1);

            if (name.Length <= 2)
            {
                label4.Text += xi + "*";

            }
            if (name.Length == 3)
            {
                label4.Text += xi + "*" + min;
            }
            else
            {
                label4.Text += xi + "**" + min;
            }
            label9.Text += DateTime.Now.ToString();
            //label6.Text = "使用须知：";
            label6.Text += "会员卡一人限办一张，不得转借他人使用；";
            label7.Text += "持卡每消费一元可积一分，积分用于兑换精美礼品";
            label10.Text += @"请在购物时主动向营业员或收银员出示会员卡,
    顾客购物若未即时出示会员卡,则不能享受相应积点
    会员卡积点在购物付款时进行，过后不再补积。";
            label8.Text += @"会员卡使用权为两年,权限前需办理续卡手续;
    否则视会员卡自动作废;";
        }

    }
}
