using DeliverApp.Module;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliverApp.ViewModel
{
    public class GenerateOrderViewModel
    {
        public GenerateOrderViewModel(string productname,string timename, string tiptext)
        {
            ProductName = productname;
            TimeName = timename;
            
            TipText = tiptext;
            
        }

        static GenerateOrderViewModel()
        {
            ProductList = new List<GenerateOrderViewModel>()
            {
               new GenerateOrderViewModel ("御泥坊化妆套装（001）",GenerateOrderModel.TimeNameText,"库编号1不存在，请查询后再操作"),
               new GenerateOrderViewModel ("御泥坊化妆套装（002）",GenerateOrderModel.TimeNameText,"库编号1不存在，请查询后再操作"),
               new GenerateOrderViewModel ("御泥坊化妆套装（003）",GenerateOrderModel.TimeNameText,"库编号1不存在，请查询后再操作"),
               new GenerateOrderViewModel ("御泥坊化妆套装（004）",GenerateOrderModel.TimeNameText,"库编号1不存在，请查询后再操作"),
               new GenerateOrderViewModel ("御泥坊化妆套装（005）",GenerateOrderModel.TimeNameText,"库编号1不存在，请查询后再操作"),


            };
        }
        public  string ProductName { get; set; }

        public  string TimeName { get; set; }

        public string TipText { get; set; }

        public string TipTitleText { get; set; }

        public static List<GenerateOrderViewModel> ProductList { get; set; }
    }
}
