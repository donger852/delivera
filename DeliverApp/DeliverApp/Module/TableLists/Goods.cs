using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module.TableLists
{
    public class Goods
    {
        /// <summary>
        /// 单号
        /// </summary>
        public string GoodsId { get; set; }
        /// <summary>
        /// 客户id
        /// </summary>
        public string CustormerId { get; set; }
        /// <summary>
        /// 仓库id
        /// </summary>
        public string StoreId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>

        public string TypeName { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
