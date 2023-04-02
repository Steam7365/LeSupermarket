using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Windows.Forms;

namespace supermarket项目
{
    class DBHelper
    {
        public static string connStr = ConfigurationManager.ConnectionStrings["SQL"].ToString();
        public static string conn = connStr;
        public static DataGridView dgv { get; set; }
        public static Cashier_GoodsInfo GoodsInfo { get; set; }
        public static Cashier_Main Cmain { get; set; }
    }
}
