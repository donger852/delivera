using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    public class SearchModel
    {
        /// <summary>
        /// 是否显示客户列表
        /// </summary>
        public static bool IsCustormerList { get; set; }
        /// <summary>
        /// 是否显示仓库列表
        /// </summary>
        public static bool Listview { get;  set; }
        /// <summary>
        /// 库位
        /// </summary>
        public static bool IsLocationList { get; set; }
        /// <summary>
        /// 仓库
        /// </summary>
        public static bool IsStoreList { get; set; }
        /// <summary>
        /// 快递公司
        /// </summary>
        public static bool IsExpressList { get; set; }
        /// <summary>
        /// 产品
        /// </summary>
        public static bool IsProductList { get; set; }


        /// <summary>
        /// 标题
        /// </summary>
        public static string SearchPageTitel { get; set; }

        public static string PageTitelClient = "客户资料(离线数据)";
        public static string PageTitelStor = "仓库资料(离线数据)";
        public static string PageTitelLocal = "库位资料(离线数据)";
        public static string PageTitelExpress = "快递资料(离线数据)";
        public static string PageTitelProduct = "产品资料(离线数据)";




       
    }
}
