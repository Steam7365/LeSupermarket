using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace supermarket项目
{
    public partial class ForTanJia : Form
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
        public ForTanJia()
        {
            InitializeComponent();
        }
        public void TinJa()
        {
            //设置姓名不能为空
            if (this.textBox2.Text == "")
            {
                MessageBox.Show("姓名不能为空!");
            }
            //电话号码不能为空
            if (this.textBox3.Text == "")
            {
                MessageBox.Show("电话号码不能为空!");
            }
            //职位 不能为空
            if (this.textBox7.Text == "")
            {
                MessageBox.Show("职位不能为空!");
            }
            //身份证只能为十八位
            if (this.textBox4.Text.Length != 18)
            {
                MessageBox.Show("身份证位数必须为十八位", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                return;
            }

            //获取内容
            int Pid = int.Parse(this.textBox1.Text);                         //编号
            string Pname = this.textBox2.Text;                               //姓名
            string Gender = this.radioButton1.Checked ? "男" : "女";              //性别 
            string Telephone = this.textBox3.Text;                           //电话
            string Id = this.textBox4.Text;                                  //身份证
            DateTime Ptime =Convert.ToDateTime( this.dateTimePicker1.Text);                        //注册时间
            string Pddress = this.textBox6.Text;                             //地址
            string Post = this.textBox7.Text;                                //职务
            string Pstate = this.comboBox1.SelectedItem.ToString();                             //状态

            //写出添加的sql
            string sql = @"insert into Employee
                    values(@Pid,@Pname,@Gender,@Telephone,@Id,@Ptime,@Pddress,@Post,@Pstate)";
            //创建连接
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {

                try
                {
                    con.Open();//连接
                               //创建command对象:指定要执行的SQL和使用的连接
                    SqlCommand scm = new SqlCommand(sql, con);
                    //保存到数据库
                    scm.Parameters.Add(new SqlParameter("@Pid", Pid));
                    scm.Parameters.Add(new SqlParameter("@Pname", Pname));
                    scm.Parameters.Add(new SqlParameter("@Gender", Gender));
                    scm.Parameters.Add(new SqlParameter("@Telephone", Telephone));
                    scm.Parameters.Add(new SqlParameter("@Id", Id));
                    scm.Parameters.Add(new SqlParameter("@Ptime", Ptime));
                    scm.Parameters.Add(new SqlParameter("@Pddress", Pddress));
                    scm.Parameters.Add(new SqlParameter("@Post", Post));
                    scm.Parameters.Add(new SqlParameter("@Pstate", Pstate));

                    //执行SQL:调用ExecuteNonQuery()执行非查询SQL，返回受影响行数
                    int row = scm.ExecuteNonQuery();
                    if (row > 0)
                    {
                        Chanzhi.Jiaz.JaZa();
                        MessageBox.Show("添加成功!");
                    }
                }
                catch 
                {

                }
                
            }
        }


        private void TanJia_Load(object sender, EventArgs e)
        {
            //设第一行为光标焦点
            this.textBox1.Focus();
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            TinJa();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            //把文本框设为空
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.comboBox1.Text = "";
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
