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
    public partial class LoginAdd : Form
    {
        public LoginAdd()
        {
            InitializeComponent();
        }
        

        private void LoginAdd_Load(object sender, EventArgs e)
        {
        }
        List<string> pid = new List<string>();
        public void aaa(string sql)
        {
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while(sdr.Read())
                        {
                            pid.Add(sdr[0].ToString());
                        }
                    }
                }
            }
        }
        public bool bbb(string sql)
        {
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        if (sdr.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 添加账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        /// <summary>
        /// 获取职务
        /// </summary>
        public string post(string sql)
        {
            string post="";
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                     post = com.ExecuteScalar().ToString();
                }
            }
            return post;
        }
        public void LoginInsert(string sql)
        {
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    try
                    {
                        com.ExecuteNonQuery();
                    }
                    catch 
                    {
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            string sql = "select pid from login";
            aaa(sql);
            if (textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("请输入完整数据！！");
                return;
            }
            if (pid.Contains(textBox4.Text))
            {
                MessageBox.Show("此员工已有账号！");
                return;
            }
            sql = $"select * from Employee where pid='{textBox4.Text}' and (Post='前台' or Post = '收银员')";
            bool b = bbb(sql);
            if (!b)
            {
                MessageBox.Show("此员工并非收银或者前台人员！！");
                return;
            }
            string postsql = $"select post from Employee where pid='{textBox4.Text}'";
            string posts = post(postsql);


            sql = $@"insert into Login
                         values('{textBox1.Text}','{textBox2.Text}','{posts}','{textBox4.Text}')";
            LoginInsert(sql);
            MessageBox.Show("添加成功！！");
            this.Close();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
