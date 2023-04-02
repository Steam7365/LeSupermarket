using supermarket项目;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace supermarket项目
{
    class Chanzhi
    {
        private static bool bo = true;
        public static Form frm { get; set; }
        public static string pwd { get; set; }
        public static ForYuanG Shax { get; set; }       //
        public static int Xueh { get; set; }            //修改    学号
        public static ForYuanG Tianc { get; set; }      //添加   编号
        public static ForYuanG Jiaz { get; set; }       //修改    列表内容
        public static string zhan { get; set; }             //用户名
        public static string zhihui { get; set; }               //职位
        public static FormZJ uidOrPwd { get; set; }//主窗体

        public static string BID { get; set; }//操作员编号
        public static bool gly { get; set; }//判断是否为管理员

        public static bool Bo
        {
            get
            {
                return bo;
            }

            set
            {
                bo = value;
            }
        }
    }
}
