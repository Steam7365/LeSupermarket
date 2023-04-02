using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supermarket项目
{
    class OriderInfoClass
    {
        public static bool day(DateTime joindate, int duration)
        {
            DateTime dt = joindate.AddDays(duration);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2.Subtract(dt);
            if (ts.Days > 0)
            {
                return true;
            }
            return false;
        }
        public static DataGridView dgv { get; set; }//获取网格视图中的所有信息
        public static string uid { get; set; }//操作员编号
        public static TextBox textPrice { get; set; }//原价
        public static TextBox textDisPrice { get; set; }//折扣优惠
        public static TextBox textVip { get; set; }//会员号
        public static TextBox textJiFen { get; set; }//积分
        public static Label labXiaoJi { get; set; }//小计
        public static RadioButton RaDioYes { get; set; }//是否会员
        public static string OriderId { get; set; }//订单号
    }
}
