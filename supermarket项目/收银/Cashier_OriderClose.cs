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
    public partial class Cashier_OriderClose : Form
    {
        public Cashier_OriderClose()
        {
            InitializeComponent();
        }
        #region 所有商品编号
        List<string> GinID = new List<string>();
        public void SuoYouID()
        {
            string sql = "select ginid from GoodsInfo";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                using (SqlCommand com=new SqlCommand(sql,con))
                {
                    con.Open();
                    using (SqlDataReader sdr = com.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            GinID.Add(sdr[0].ToString());
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 将需要的信息显示在网格视图中
        /// </summary>
        /// <param name="sql"></param>
        public void GoodsInfo(string sql)
        {
            DataSet dSet = new DataSet();
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                sda.Fill(dSet);
                dataGridView1.DataSource = dSet.Tables[0];
                //把购买数量全部设置为数组内容
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["Column6"].Value = gbCount[i];
                }
            }
        }

        /// <summary>
        /// 加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cashier_OriderClose_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(246, 246, 246);
            SuoYouID();
            //strLabel1.Text += "5";
            OriderInfoClass.uid = "5";//用户名
            textBox3.Text = "0.00";//原价
            textBox4.Text = "0.00";//折后价
            b = false;//加载完毕

            //list有值
            for (int i = 0; i < 1000; i++)
            {
                gbCount.Add(1);
            }
        }


        bool b = true;//判断是否加载完毕
        List<int> gbCount = new List<int>();//存储每个商品的购买数量
        double price = 0;//存储原价的值
        double disprice = 0;//存储折扣价的值
        List<string> gbID = new List<string>();//用来存储在视图显示的商品编号
        //命令语句
        string sql = $@"select ginid,gname,gspecs,gprice,disprice,1 as gbcount
                         from GoodsInfo
                         where 0=1";
        List<int> gbPX = new List<int>();
        /// <summary>
        /// 添加输入的购买的商品信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox2.Location = new Point(pictureBox2.Location.X + 5, pictureBox2.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox2.Location = new Point(pictureBox2.Location.X - 5, pictureBox2.Location.Y - 5);

            bf = false;//不使用单元格内容改变事件
            #region 判断输入的编号是否存在
            bool nn =false;
            for (int i = 0; i < GinID.Count; i++)
            {
                if (GinID[i]==textID.Text)
                {
                    nn = true;
                    break;
                }
            }
            for (int i = 0; i < gbPX.Count; i++)
            {
                if (gbPX[i].ToString()==textID.Text)
                {
                    nn = false;
                    break;
                }
            }
            if (!nn)
            {
                return;
            }
            #endregion

            for (int i = 0; i < gbPX.Count; i++)
            {
                //if (gbPX[i].ToString() == str)
                //{
                //    gbCount.Insert(i, 1);
                //    str = "";
                //}
                if (int.Parse(textID.Text) < gbPX[i])
                {
                    gbCount.Insert(i, 1);
                    break;
                }
            }
            //显示一行输入的信息
            gbID.Add(textID.Text);
            gbPX.Add(int.Parse(textID.Text));
            sql += $"or ginid='{gbID[gbID.Count-1]}'";
            //判断是否有删除的数据
            gbPX.Sort();
            
            GoodsInfo(sql);
            //判断视图是否为空和是否输入值
            if (dataGridView1.Rows.Count == 0 || textID.Text == "")
            {
                return;
            }
            //选中时的背景色
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 192, 203);//粉色
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                gbCount[i] = int.Parse(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
            }
            Info();
            price = double.Parse(textBox3.Text);
            //小计
            disprice = double.Parse(textBox3.Text)-double.Parse(textBox4.Text);
            textID.Text = "";
            bf = true;
        }

        /// <summary>
        /// 添加一行数据将原价等数据填值
        /// </summary>
        public void Info()
        {
            try
            {
                double text3 = 0;
                double text4 = 0;
                double text5 = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //原价显示
                    text3 = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column4"].Value.ToString()) * Convert.ToDouble(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                    text4 += text3;
                    this.textBox3.Text = text4.ToString("F2");
                    //显示折扣价
                    text3 = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column5"].Value.ToString()) * Convert.ToDouble(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                    text5 += text3;
                    textBox4.Text = (double.Parse(textBox3.Text) - text5).ToString("F2");

                    //小计
                    labSubtotal.Text = text5.ToString("F2") + " 元";
                    //判断是否打开了是选项
                    if (!radioButton2.Checked)
                    {
                        //打开后积分内容显示与原价一致
                        textBox5.Text = textBox3.Text;
                    }
                }
            }
            catch
            {
            }

        }
        /// <summary>
        /// 单元格内容改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        bool bf = true;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //若加载未完成返回该事件
            if (b || !bf)
            {
                return;
            }
            try
            {
                if (int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Column6"].Value.ToString()) == 1)
                {
                    return;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    gbCount[i] = int.Parse(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                }
                Info();
                price = double.Parse(textBox3.Text);
                //小计
                disprice = double.Parse(textBox3.Text) - double.Parse(textBox4.Text);
            }
            catch
            {
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Column6"].Value = "1";
            }
        }

        /// <summary>
        /// 双击购买数量加一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        private void dataGridView1_CellContentDoubleClick(object sender, EventArgs e)
        {
            //判断选中的这个列的值是否是减去数量按钮
            if (dataGridView1.SelectedCells[0].Value.ToString() != dataGridView1.Rows[0].Cells["Column7"].Value.ToString())
            {
                bf = false;
                //把选中的列的行数全选
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Selected = true;
                //dataGridView1.RowHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(251, 176, 59)
                //购买数量加一
                dataGridView1.SelectedRows[0].Cells["Column6"].Value = int.Parse(dataGridView1.SelectedRows[0].Cells["Column6"].Value.ToString()) + 1;


                //显示原价信息
                this.price += Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
                this.textBox3.Text = this.price.ToString("F2");
                //显示折扣价
                this.disprice += Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["Column5"].Value.ToString());
                textBox4.Text = (double.Parse(textBox3.Text) - disprice).ToString("F2");
                //小计
                labSubtotal.Text = disprice.ToString("F2") + " 元";
                //判断是否打开了是选项
                if (!radioButton2.Checked)
                {
                    //打开后积分内容显示与原价一致
                    textBox5.Text = textBox3.Text;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    gbCount[i] = int.Parse(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                }
                bf = true;
            }

        }

        /// <summary>
        /// 点击按钮购买数量减一
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, EventArgs e)
        {
            //判断所选的这列的购买数量是否为1

            if (int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Column6"].Value.ToString()) == 1)
            {
                return;
            }

            //判断选中的这列是否是减去数量按钮
            if (dataGridView1.SelectedCells[0].Value.ToString() == dataGridView1.Rows[0].Cells["Column7"].Value.ToString())
            {
                bf = false;
                //购买数量减一
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Column6"].Value = int.Parse(dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["Column6"].Value.ToString()) - 1;
                dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Selected = true;

                //显示原价信息
                this.price -= Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["Column4"].Value.ToString());
                this.textBox3.Text = this.price.ToString("F2");
                //显示折扣价
                this.disprice -= Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["Column5"].Value.ToString());
                textBox4.Text = (double.Parse(textBox3.Text) - disprice).ToString("F2");
                //小计
                labSubtotal.Text = disprice.ToString("F2") + " 元";
                //判断是否打开了是选项
                if (!radioButton2.Checked)
                {
                    //打开后积分内容显示与原价一致
                    textBox5.Text = textBox3.Text;
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    gbCount[i] = int.Parse(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                }
                bf = true;
            }
        }
        string str = "";
        private void 删除此列ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //重置语句
            sql = $@"select ginid,gname,gspecs,gprice,disprice,1 as gbcount
                       from GoodsInfo
                       where 0=1";
            //判断是否有选中的值
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            //先获取要删除的编号
            str= dataGridView1.SelectedRows[0].Cells["Column1"].Value.ToString();
            //删除选中的行
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(item);
            }
            //购买数量更新
            for (int i = 0; i < gbCount.Count; i++)
            {
                if (dataGridView1.Rows.Count - 1 >= i)
                {
                    gbCount[i] = int.Parse(dataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                }
                else
                {
                    gbCount[i] = 1;
                }
            }
            //修改商品编号相同的子集
            for (int i = 0; i < gbID.Count; i++)
            {
                if (gbID[i]==str)
                {
                    gbID.RemoveAt(i);
                    gbPX.Remove(int.Parse(str));
                }
            }
            //把修改后的集合重新赋值给sql语句
            for (int i = 0; i < gbID.Count; i++)
            {
                sql += $"or ginid='{gbID[i]}'";
            }
            bf = false;
            //刷新视图
            GoodsInfo(sql);
            //价格信息刷新
            Info();
            //价格赋值
            price = double.Parse(textBox3.Text);
            //小计
            disprice = double.Parse(textBox3.Text) - double.Parse(textBox4.Text);
            //判断网格表中是否还有数据
            if (dataGridView1.Rows.Count==0)
            {
                //没数据把价格归0
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                labSubtotal.Text = "0 元";
            }
        }


        /// <summary>
        /// 点击“是”选项按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //点击后
            if (!radioButton2.Checked)
            {
                //取消会员与积分禁用并赋值积分分数
                textBox5.Enabled = true;
                textBox2.Enabled = true;
                textBox5.Text = textBox3.Text;
            }
            else
            {
                //禁用会员与积分框并清空内容
                textBox2.Text = "";
                textBox2.Enabled = false;                textBox5.Text = "";
                textBox5.Enabled = false;
            }
        }
        List<string> vip = new List<string>();//用来存入会员号
        /// <summary>
        /// 获取会员号码
        /// </summary>
        public void VipPhone()
        {
            //读取会员号语句
            string sql = "select Phone from VipInfo";
            using (SqlConnection con = new SqlConnection(DBHelper.connStr))
            {
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    con.Open();
                    //读取数据库中会员号码信息
                    using (SqlDataReader sr = com.ExecuteReader())
                    {
                        //给vip填值
                        while (sr.Read())
                        {
                            this.vip.Add(sr[0].ToString());
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 提交购买信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //闪动图片
            pictureBox1.Location = new Point(pictureBox1.Location.X + 5, pictureBox1.Location.Y + 5);
            Thread.Sleep(100);
            pictureBox1.Location = new Point(pictureBox1.Location.X - 5, pictureBox1.Location.Y - 5);            //判断是否点单
            //判断原价是否为0
            if (textBox3.Text == "0.00")
            {
                return;
            }
            //判断是否为会员
            if (!radioButton2.Checked)
            {
                //判断是否输入会员号
                if (textBox2.Text == "")
                {
                    MessageBox.Show("请填写会员！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                bool b = false;//判断是否有此会员
                //获取所有会员信息
                VipPhone();
                //判断输入的会员号是否存在
                for (int i = 0; i < vip.Count; i++)
                {
                    if (textBox2.Text == vip[i])
                    {
                        b = true;
                        break;
                    }
                }
                if (b)
                {
                    OriderInfoClass.dgv = dataGridView1;//视图信息
                    OriderInfoClass.textPrice = textBox3;//原价
                    OriderInfoClass.textDisPrice = textBox4;//优惠
                    OriderInfoClass.textVip = textBox2;//会员
                    OriderInfoClass.textJiFen = textBox5;//积分
                    OriderInfoClass.labXiaoJi = labSubtotal;//小计
                    OriderInfoClass.RaDioYes = radioButton1;//是否会员
                    OriderInfo of = new OriderInfo();
                    of.ShowDialog();
                }
                else
                {
                    MessageBox.Show("无此会员");
                }
                //交易后清空会员信息
                vip.Clear();
            }
            else
            {
                OriderInfoClass.dgv = dataGridView1;//视图信息
                OriderInfoClass.textPrice = textBox3;//原价
                OriderInfoClass.textDisPrice = textBox4;//优惠
                OriderInfoClass.textVip = textBox2;//会员
                OriderInfoClass.textJiFen = textBox5;//积分
                OriderInfoClass.labXiaoJi = labSubtotal;//小计
                OriderInfoClass.RaDioYes = radioButton1;//是否会员
                OriderInfo of = new OriderInfo();
                of.ShowDialog();
            }
            if (Class1.JieZhang)
            {
                DBHelper.Cmain.Jiezhang(sender,e);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }


    }
}
