using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DeliverApp.Module
{
    public class ProduceManegeModel
    {
        /// <summary>
        /// 入库管理
        /// </summary>
        public static bool IsInput { get; set; }
        /// <summary>
        /// 发货管理
        /// </summary>
        public static bool IsOutput { get; set; }
        /// <summary>
        /// 退货管理
        /// </summary>
        public static bool Send { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public static string ProduceManegePageTitle { get; set; }


        public static string InputBtnName = "正常入库";
        public static string OutputBtnName = "退货入库";
        public static string OnStockName = "已入库产品发货";
        public static string UnStorgeName = "不入库直接发货";

        public static string DetailName = "订单详情";


        public static string timename= DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


       







    }
}
