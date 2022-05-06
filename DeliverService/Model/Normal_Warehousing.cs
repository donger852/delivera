using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;

namespace DeliverService.Model
{
    public class Normal_Warehousing
    {
        /// <summary>
        /// 条码编号
        /// </summary>
        [Column(IsIdentity = true, IsPrimary = true)]
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
         /// 生成批号
         /// </summary>
        public string Lotnum { get; set; }
     
        /// <summary>
        /// 生产时间
        /// </summary>
        public DateTime CodeTime { get; set; }
      
    }

}
