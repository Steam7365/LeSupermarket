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
    
    public partial class ForYuanG : Form
    {
        public ForYuanG()
        {
            InitializeComponent();
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //判断有没有选中
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中一个员工!");
                return;
            }
            //保存选中学生的学号
            Chanzhi.Xueh = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
            //保存当前窗体实例
            Chanzhi.Tianc = this;
            //切换到修改信息窗口
            ForXiGai xg = new ForXiGai();
            xg.Show();

        }

        private void ForYuanG_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(246, 246, 246);
            this.label6.Text = zhanh;
            //调用方法
            Chanzhi.Jiaz = this;
            JaZa();
        }
        public void JaZa()
        {
            //查询表
            string sql = @"select * from Employee";
            DataSet ds = new DataSet();//创建临时仓库
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                //打开零时仓库
                SqlDataAdapter DS = new SqlDataAdapter(sql, con);
                DS.Fill(ds);//内容保存到表中
                            //内容显示在表格中
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }


        public void CaXn()
        {
            //写出查询的sql
            string sql = @"select * from Employee where 1=1";
            if (this.textBox1.Text != "")           //输入编号
            {
                sql += "and Pid=@Pid";
            }
            if (this.textBox2.Text != "")           //输入了姓名
            {
                sql += "and Pname=@Pname";
            }
            if (this.comboBox1.Text != "")           //输入了状态
            {
                sql += "and Pstate like @Pstate";
            }
            if (this.textBox4.Text != "")           //输入了职位
            {
                sql += "and Post like @Post";
            }
            DataSet ds = new DataSet();                 //创建临时仓库
            using (SqlConnection scon = new SqlConnection(DBHelper.connStr))
            {       //写指定参数
                SqlDataAdapter da = new SqlDataAdapter(sql, scon);
                da.SelectCommand.Parameters.Add(new SqlParameter("@Pid", this.textBox1.Text));
                da.SelectCommand.Parameters.Add(new SqlParameter("@Pname", this.textBox2.Text));
                da.SelectCommand.Parameters.Add(new SqlParameter("@Pstate", "%" + this.comboBox1.Text + "%"));
                da.SelectCommand.Parameters.Add(new SqlParameter("@Post", "%" + this.textBox4.Text + "%"));
                da.Fill(ds);        //填充临时仓库
                //显示在datagriview1中
                this.dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //调用添加员工方法
            chuan();
        }
        public void chuan()
        {
            //保存窗口实例
            Chanzhi.Shax = this;
            //切换窗口
            ForTanJia fyg = new ForTanJia();
            fyg.Show();
        }

        private void 删除ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string sql = "delete from Login where pid=@Pid";
            Shan(sql);
            if (sb )
            {
                sb = false;
                return;
            }
            //调用删除方法
             sql = "delete from Employee where Pid=@Pid"; //删除的sql
            Shan(sql);
            //刷新
            JaZa();

        }
        bool  sb = false;
        public void Shan(string sql)
        {

            //判断有没有选中
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                this.sb = true;
                MessageBox.Show("请选中一个学生!");
                return;
            }

            //询问是否确定删除？
            DialogResult dr = MessageBox.Show("是否确定删除该员工?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK) //点击确定按钮
            {
                //----删除操作过程---
                //获取选中的学号
                int sid = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                
                using (SqlConnection conn = new SqlConnection(DBHelper.connStr))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add(new SqlParameter("@Pid", sid));
                        int row = cmd.ExecuteNonQuery();//执行非查询
                        if (row > 0)
                        {
                            
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }

            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //调用返回方法
            fanghui();
        }
        public void fanghui()
        {
            //切换窗口
            this.Close();
            FormZJ d = new FormZJ();
            d.Show();

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //判断有没有选中
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中一个员工!");
                return;
            }
            //保存选中学生的学号
            Chanzhi.Xueh = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
            //保存当前窗体实例
            Chanzhi.Tianc = this;
            // 切换修改窗口
            ForXiGai xg = new ForXiGai();
            xg.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            chuan();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //删除
            //判断有没有选中
            if (this.dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选中一个员工！");
                return;//返回
            }
            //判断是职位是否为管理员
            if (this.dataGridView1.SelectedRows[0].Cells[7].Value.ToString() == "管理员")
            {
                MessageBox.Show("您没有权限删除管理员!");
                return;
            }

            //询问是否确定删除？
            DialogResult dr = MessageBox.Show("是否确定删除该员工?", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {

                //获取选中的学号
                int sid = (int)this.dataGridView1.SelectedRows[0].Cells[0].Value;
                //写出删除的sql
                string sql = "delete from Employee where Pid=@Pid";
                //创建连接
                using (SqlConnection conn = new SqlConnection(DBHelper.connStr))
                {
                    try
                    {
                        //连接
                        conn.Open();
                        //创建对象，执行选定的对象
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        cmd.Parameters.Add(new SqlParameter("@Pid", sid));
                        int row = cmd.ExecuteNonQuery();//执行非查询
                        if (row > 0)
                        {
                            //刷新
                            JaZa();
                            //重新查询一次数据
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }

                }
            }
        }
        bool b = false;
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Cashier_Boss boss = new Cashier_Boss();
            boss.Show();
            b = true;
            this.Close();

        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //无条件退出
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            //无条件退出
            this.Close();
        }


        public string zhanh { get; set; }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            pictureBox2.Location = new Point(pictureBox2.Location.X + 3, pictureBox2.Location.Y + 3);
            Thread.Sleep(100);
            pictureBox2.Location = new Point(pictureBox2.Location.X - 3, pictureBox2.Location.Y - 3);
            //调用查询方法
            CaXn();
        }

        private void ForYuanG_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (b)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("是否退出系统！！", "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            //若点击取消就取消关闭事件
            if (dr != DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                Chanzhi.uidOrPwd.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            LoginInfo login = new LoginInfo();
            login.ShowDialog();
        }
    }
}
