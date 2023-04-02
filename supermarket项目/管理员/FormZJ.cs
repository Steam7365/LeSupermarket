using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using supermarket项目;
using System.Data.SqlClient;
using System.Threading;

namespace supermarket项目
{
    public partial class FormZJ : Form
    {
        public FormZJ()
        {
            InitializeComponent();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(pictureBox2.Location.X + 3, pictureBox2.Location.Y + 3);
            Thread.Sleep(100);
            pictureBox2.Location = new Point(pictureBox2.Location.X - 3, pictureBox2.Location.Y - 3);
            Chax();
            Bid();//获取用户名编号
            Chanzhi.pwd = textBox2.Text;

        }
        /// <summary>
        /// 根据用户名获取对应编号
        /// </summary>
        public void Bid()
        {
            string sql = "select Bid,bname From Login";
            using (SqlConnection con=new SqlConnection(DBHelper.connStr))
            {
                con.Open();
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    using (SqlDataReader sdr=com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            if (sdr[1].ToString()==textBox1.Text)
                            {
                                Chanzhi.BID = sdr[0].ToString();
                            }
                        }
                    }
                }
            }
        }
        public void Chax()
        {
            //获取文本框的账号密码
            string Bname = this.textBox1.Text;
            string Bword = this.textBox2.Text;
            //查询的sql
            string sql = "select * from Login where Bname=@Bname and Bword=@Bword ";
            //using用完销毁对象
            using (SqlConnection sc = new SqlConnection(DBHelper.connStr))
            {
                //try：异常捕获
                try
                {
                    sc.Open();      //连接
                    //4、创建command对象:指定要执行的SQL和使用的连接
                    SqlCommand cmd = new SqlCommand(sql, sc);
                    cmd.Parameters.Add(new SqlParameter("@Bname", Bname));
                    cmd.Parameters.Add(new SqlParameter("@Bword", Bword));
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        //读取列的数据
                        string name = dr[1].ToString();
                        string pwd = dr[2].ToString();
                        string zhiwei = dr[3].ToString();

                        //如果职位为管理员，则执行括号内代码
                        if (zhiwei == "经理")
                        {
                            Chanzhi.gly = true;
                            Cashier_Boss boss = new Cashier_Boss();
                            Chanzhi.zhan = Bname;
                            boss.Show();
                            this.Hide();
                        }
                        //如果职位为收银员，则执行括号内代码
                        if (zhiwei == "收银员")
                        {
                            Chanzhi.gly = false;//非管理员
                            Cashier_Main Cashier = new Cashier_Main();
                            Chanzhi.zhan = Bname;
                            Cashier.Show();
                            this.Hide();
                        }
                        //如果职位为前台，则执行括号内代码
                        if (zhiwei == "前台")
                        {
                            Chanzhi.gly = false;//非管理员
                            窗体设置测试 QianTai = new 窗体设置测试();
                            Chanzhi.zhan = Bname;
                            QianTai.Show();
                            this.Hide();
                        }
                    }
                    else//未查询到账号密码则为错误
                    {
                        MessageBox.Show("账号或密码错误");
                    }
                    dr.Close();//关闭连接
                }
                catch (Exception ex)
                {
                    //提示错误
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {
            this.label4.BackColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            this.label4.BackColor = Color.WhiteSmoke;
        }

        private void FormZJ_Load(object sender, EventArgs e)
        {
            Chanzhi.uidOrPwd = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }
    }
}
