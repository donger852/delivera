using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    public class GenerateOrderModel
    {
        public static string TimeNameText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

        /// <summary>
        /// 标题单号
        /// </summary>
        public static string OrderTitleName { get; set; }
        /// <summary>
        /// 是否显示选择列表（产品，库位，客户，生产日期、批号）
        /// </summary>
        public static bool IsOnStockActive { get; set; }
        /// <summary>
        /// 是否显示选择产品
        /// </summary>
        public static bool IsSelectProductAvtive { get; set; }
        /// <summary>
        /// 是否显示选择库位
        /// </summary>
        public static bool IsSelectPlaceActive { get; set; }
        /// <summary>
        /// 是否显示选择客户
        /// </summary>
        public static bool IsSelectClientActive { get; set; }
        /// <summary>
        /// 是否显示生产日期、批号
        /// </summary>
        public static bool IsSelectCreateActive { get; set; }

       






    }
}
