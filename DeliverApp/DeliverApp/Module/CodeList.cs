using DeliverApp.Module.TableLists;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    public class CodeList
    {
        /// <summary>
        /// 条码
        /// </summary>
        public string CodeId { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public static string GoodsId { get; set; }

        /// <summary>
        /// 产品Id
        /// </summary>
        public static string ProductId { get; set; }
    
        /// <summary>
        /// 库位Id
        /// </summary>
        public static string LocationId { get; set; }

        public static string CustormerId { get; set; }

        /// <summary>
        /// 生成批号
        /// </summary>
        public static string Lotnum { get; set; }

        /// <summary>
        /// 生产时间
        /// </summary>
        public static DateTime CodeTime { get; set; }
    }
}
