using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    public class WarehouseModel
    {
        /// <summary>
        /// 是否开启显示选择客户  一级
        /// </summary>
        public static bool IsSeleteClients { get; set; }
        /// <summary>
        /// 是否开启显示选择仓库 一级
        /// </summary>
        public static bool IsSeleteStor { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public static string WarehousePageTitle { get; set; }
   

        public static string BtnSelectText { get; set; }
    }
}
