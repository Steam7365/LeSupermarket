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
    public partial class LoginInfo : Form
    {
        public LoginInfo()
        {
            InitializeComponent();
        }

        public void Login(string sql)
        {
            DataSet dSet = new DataSet();
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql,con);
                sda.Fill(dSet);
                dataGridView1.DataSource = dSet.Tables[0];
            }
        }
        private void LoginInfo_Load(object sender, EventArgs e)
        {
            string sql = @"select l.Bid, e.Pname,l.Bposition,l.Bname,l.Bword from Employee e JOIN Login l
                            on e.Pid = l.Pid";
            Login(sql);
        }

        private void 添加账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginAdd loginAdd = new LoginAdd();
            loginAdd.ShowDialog();
            LoginInfo_Load(sender, e);
        }

        private void 删除账号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = $"delete Login where bid='{dataGridView1.SelectedRows[0].Cells[0].Value.ToString()}'";
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    com.ExecuteNonQuery();
                }
            }
            sql= @"select l.Bid, e.Pname,e.Post,l.Bname,l.Bword from Employee e JOIN Login l
                            on e.Pid = l.Pid";
            Login(sql);
        }
    }
}
