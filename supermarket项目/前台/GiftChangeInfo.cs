using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supermarket项目
{
    public partial class GiftChangeInfo : Form
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
        public GiftChangeInfo()
        {
            InitializeComponent();
        }

        private void GiftChangeInfo_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            this.BackColor = Color.FromArgb(254, 235, 235);
            dataGridView1.BackgroundColor = Color.FromArgb(254, 235, 235);
            dataGridView1.AllowUserToAddRows = false;
          //  this.dataGridView1.Rows[0].Selected = false;
            string sql = "select Cid,Phone, GiftID,Time,GName,much,bid  from GiftChange a inner join GoodsInfo b on a.GiftID=b.ginid";
            using (SqlConnection a = new SqlConnection(DBHelper.conn))
            {
                DataSet b = new DataSet();
                SqlDataAdapter c = new SqlDataAdapter(sql, a);
                c.Fill(b);
                dataGridView1.DataSource = b.Tables[0];
            }
            //this.dataGridView1.Rows[0].Selected = false;
        }
    }
}
