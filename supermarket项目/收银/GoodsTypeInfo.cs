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
    public partial class GoodsTypeInfo : Form
    {
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
        public static string q;
        public GoodsTypeInfo(string str)
        {
            q = str;
            InitializeComponent();
        }

        private void GoodsTypeInfo_Load(object sender, EventArgs e)
        {
            string sql = $@"select i.*,t.GType from GoodsInfo i join GoodsType t
                            on i.GId = t.GId
                            where t.Gid='{q}'";
            DataSet a = new DataSet();
            using (SqlConnection b = new SqlConnection(DBHelper.connStr))
            {
                SqlDataAdapter c = new SqlDataAdapter(sql, b);
                c.Fill(a);
                dataGridView1.DataSource = a.Tables[0];
            }
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
        }
    }
}
