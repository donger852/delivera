using DeliverApp.Module;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeliverApp.Help
{
    public class ServerHelp
    {

        /// <summary>
        /// 入、发、退货管理
        /// </summary>
        /// <param name="isinput">是否显示入库管理</param>
        /// <param name="isoutput">是否显示发货管理</param>
        /// <param name="send">是否显示退货管理</param>
        /// <param name="title">标题</param>
        public static void SelectManageMethod(bool isinput,bool isoutput,bool send , string title) 
        {
            ProduceManegeModel.IsInput = isinput;
            ProduceManegeModel.IsOutput = isoutput;
            ProduceManegeModel.Send = send;
            ProduceManegeModel.ProduceManegePageTitle = title;

        }


        /// <summary>
        /// 管理一二级页面
        /// </summary>
        /// <param name="isseletestor">是否显示选择仓库</param>
        /// <param name="isseleteclients">是否显示选择客户</param>
        /// <param name="pagetitle">page标题</param>
        /// <param name="isonstockactive">是否显示选择仓库 二级页面</param>
        /// <param name="isselectplaceactive">是否显示选择库位  二级页面</param>
        /// <param name="isselectproductavtive">是显示否选择产品 二级页面</param>
        /// <param name="isselectclientactive">是否显示选择客户 二级页面</param>
        /// <param name="isselectcreateactive"> 是否显示选择生产日期/批号  二级页面</param>
        public static void ManageMethod(bool isseletestor, bool isseleteclients, string pagetitle, bool isonstockactive, 
           bool isselectplaceactive, bool isselectproductavtive, bool isselectclientactive, bool isselectcreateactive)
        {
            WarehouseModel.WarehousePageTitle = pagetitle;
            WarehouseModel.IsSeleteStor = isseletestor;
            WarehouseModel.IsSeleteClients = isseleteclients;

            GenerateOrderModel.IsOnStockActive = isonstockactive;
            GenerateOrderModel.IsSelectPlaceActive = isselectplaceactive;
            GenerateOrderModel.IsSelectProductAvtive = isselectproductavtive;
            GenerateOrderModel.IsSelectClientActive = isselectclientactive;
            GenerateOrderModel.IsSelectCreateActive = isselectcreateactive;
          //  SearchModel.SearchPageTitel = pagetitle;
        }




        /// <summary>
        /// 列表搜索页面
        /// </summary>
        /// <param name="listview">是否显示列表</param>
        /// <param name="searchpagetitle">页面标题</param>
        public static void SearchMethod(bool listview,  string searchpagetitle)
        {
           
            SearchModel.Listview = listview;
           
            SearchModel.SearchPageTitel = searchpagetitle;
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="defaultlist"></param>
        /// <param name="delectlist"></param>
        /// <param name="allinsertbtn"></param>
        /// <param name="alldelectbtn"></param>
        public static void SelectCampanyMethod (bool defaultlist, bool delectlist, bool allinsertbtn, bool alldelectbtn)
        {
            SelectCampanyModel.IsDefaultList = defaultlist;
            SelectCampanyModel.IsDelectList = delectlist;
            SelectCampanyModel.IsAllInsertBtn = allinsertbtn;
            SelectCampanyModel.IsAllDelectBtn = alldelectbtn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iscustormerist">客户</param>
        /// <param name="isstorelist">仓库</param>
        /// <param name="islocationlist">库位</param>
        /// <param name="isproductlist">产品</param>
        /// <param name="isexpresslist">快递公司</param>
        public static void ListViewMethod(bool iscustormerist, bool isstorelist,bool islocationlist,bool isproductlist, bool isexpresslist) { 
            SearchModel.IsCustormerList= iscustormerist;
            SearchModel.IsExpressList= isexpresslist;
            SearchModel.IsLocationList= islocationlist;
            SearchModel.IsProductList= isproductlist;
            SearchModel.IsStoreList= isstorelist;
        }
    }
}
