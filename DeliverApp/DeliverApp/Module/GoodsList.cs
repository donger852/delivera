using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.Module
{
    public class GoodsList
    {
        [PrimaryKey ]
        public string GoodsId { get; set; }
        public string CustormerId { get; set; }
        public string StoreId { get; set; }
        public string TypeName { get; set; }
        public DateTime CreateTime { get; set; }



    }
}
