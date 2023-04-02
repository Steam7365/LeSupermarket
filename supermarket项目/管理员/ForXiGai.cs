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
    public partial class ForXiGai : Form
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
        public ForXiGai()
        {
            InitializeComponent();
        }
        public void XIug()
        {
            //获取信息
            int Pid = int.Parse(this.textBox1.Text);                         //编号
            string Pname = this.textBox2.Text;                               //姓名
            string Gender = this.radioButton1.Checked ? "男" : "女";              //性别 
            string Telephone = this.textBox3.Text;                           //电话
            string Id = this.textBox4.Text;                                  //身份证
            string Ptime = this.dateTimePicker1.Value.ToString("yyyy-MM-dd");                        //注册时间
            string Pddress = this.textBox6.Text;                             //地址
            string Post = this.textBox7.Text;                                //职务
            string Pstate = this.comboBox1.Text;                             //状态
            //写出修改的sql
            string sql = @"update Employee
                   set Pname=@Pname,Gender=@Gender,Telephone=@Telephone,Id=@Id,Ptime=@Ptime,Pddress=@Pddress,Post=@Post,Pstate=@Pstate
                        where Pid=@Pid";
            //创建连接
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                //连接
                con.Open();
                //创建命令对象    
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

                //执行非查询
                int row = scm.ExecuteNonQuery();
                if (row > 0)
                {
                    Chanzhi.Jiaz.JaZa();
                    MessageBox.Show("修改成功!");
                }
            }
        }

        private void XiGai_Load(object sender, EventArgs e)
        {
            //textebox2设为光标焦点，
            this.textBox2.Focus();
            //调用窗体加载时方法
            JzXX();
        }
        public void JzXX()
        {
            //写出查询的sql
            string sql = @"select * from Employee where Pid=@Pid";
            //创建连接
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                try
                {
                    //连接
                    con.Open();
                    //创建对象
                    SqlCommand cod = new SqlCommand(sql, con);
                    cod.Parameters.Add(new SqlParameter("@Pid", Chanzhi.Xueh));
                    SqlDataReader sdr = cod.ExecuteReader();
                    if (sdr.Read())
                    {
                        //读取列的数据
                        int Pid = (int)sdr[0];
                        string Pname = sdr[1].ToString();
                        string Gender = sdr[2] + "";
                        string Telephone = sdr[3].ToString();
                        string Id = sdr[4].ToString();
                        string Ptime = sdr[5].ToString();
                        string Pddress = sdr[6].ToString();
                        string Post = sdr[7].ToString();
                        string Pstate = sdr[8].ToString();

                        //把数据放进文本框中
                        this.textBox1.Text = Pid.ToString();
                        this.textBox2.Text = Pname;
                        if (Gender == "男")
                        {
                            this.radioButton1.Checked = true;
                        }
                        else
                        {
                            this.radioButton2.Checked = true;
                        }
                        this.textBox3.Text = Telephone;
                        this.textBox4.Text = Id;
                        this.dateTimePicker1.Text = Ptime;
                        this.textBox6.Text = Pddress;
                        this.textBox7.Text = Post;
                        this.comboBox1.Text = Pstate;
                    }
                    sdr.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            XIug();
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
