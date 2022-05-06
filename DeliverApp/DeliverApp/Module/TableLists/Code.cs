using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module.TableLists
{
    public class Code
    {
        /// <summary>
        /// 条码
        /// </summary>
        public string CodeId { get; set; }
        /// <summary>
        /// 单号
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 单号列表
        /// </summary>
        public Goods Goods { get; set; }
        /// <summary>
        /// 产品Id
        /// </summary>
        public string ProductId { get; set; }
        /// <summary>
        /// 产品列表
        /// </summary>
        public Product Product { get; set; }
        /// <summary>
        /// 库位Id
        /// </summary>
        public string LocationId { get; set; }
        /// <summary>
        /// 库位表
        /// </summary>
        public Location Location { get; set; }
        /// <summary>
        /// 客户Id
        /// </summary>
        public string CustormerId { get; set; }
        /// <summary>
        /// 客户表
        /// </summary>
        public Custormers Custormers { get; set; }

        /// <summary>
        /// 生成批号
        /// </summary>
        public string Lotnum { get; set; }

        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime CodeTime { get; set; }
    }
}
