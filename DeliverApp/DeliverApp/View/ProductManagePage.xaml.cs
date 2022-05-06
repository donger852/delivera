using DeliverApp.Help;
using DeliverApp.Module;
using DeliverApp.View.ManagementView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductManagePage : ContentPage
    {
        public ProductManagePage()
        {
            InitializeComponent();
            Title = ProduceManegeModel.ProduceManegePageTitle;
            //入库管理
            Input.IsVisible = ProduceManegeModel.IsInput;
            //退货管理
            Output.IsVisible = ProduceManegeModel.IsOutput;
            //发货管理
            Send.IsVisible = ProduceManegeModel.Send;
            InputBtn.Text = ProduceManegeModel.InputBtnName;
            OutputBtn.Text = ProduceManegeModel.OutputBtnName;
            UnStorge.Text=ProduceManegeModel.UnStorgeName;
            OnStock.Text = ProduceManegeModel.OnStockName;


            //查看入库单据
            InputList.Clicked += InputList_Clicked;
           
            //正常入库
            InputBtn.Clicked += InputBtn_Clicked;

            // 已入库产品发货
            OnStock.Clicked += OnStock_Clicked;

            //不入库直接发货
            UnStorge.Clicked+= UnStorge_Clicked;        

            //按订单查看出货单据
            GoodsList.Clicked += GoodsList_Clicked;

            //按条码查看出库单据
            CodeList.Clicked += CodeList_Clicked;

            //查看扫码数统计
            SCanTotal.Clicked += SCanTotal_Clicked;

            //退货入库
            OutputBtn.Clicked += OutputBtn_Clicked;

            //查看退货单据
            OutputList.Clicked += OutputList_Clicked;



        }


        #region 入库管理
        /// <summary>
        /// 正常入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void InputBtn_Clicked(object sender, EventArgs e)
        {
            OrderList.typename = ProduceManegeModel.InputBtnName;
            OrderList.client_id = null;
            ServerHelp.ManageMethod(true, false, ProduceManegeModel.InputBtnName, true, true, true, false, true);
            await Navigation.PushAsync(new WarehousePage() { 

            });
        }
        /// <summary>
        /// 查看入库单据
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private async void InputList_Clicked(object senders, EventArgs e) {


            await Navigation.PushAsync(new DetailPage()
            { 
                Title="查看入库订单"
                
            });
        }
       
        #endregion



        #region 发货管理

        /// <summary>
        /// 已入库产品发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnStock_Clicked(object sender, EventArgs e)
        {
            OrderList.typename = ProduceManegeModel.OnStockName;
            OrderList.store_id=null;
            ServerHelp.ManageMethod(false, true, ProduceManegeModel.OnStockName, false, true, true, false, true);

            await Navigation.PushAsync(new WarehousePage()) ;

        }
        /// <summary>
        /// 不入库直接发货
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void UnStorge_Clicked(object sender, EventArgs e)
        {
            OrderList.typename = ProduceManegeModel.UnStorgeName;
            OrderList.store_id=null;
            ServerHelp.ManageMethod(false, true, ProduceManegeModel.UnStorgeName, true,  false, true, false, true);

            await Navigation.PushAsync(new WarehousePage());

        }
        /// <summary>
        /// 按订单查看出货单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoodsList_Clicked(object sender, EventArgs e) {
            ServerHelp.SearchMethod(false, GoodsList.Text);

            Navigation.PushAsync(new DetailPage());
        }
        /// <summary>
        /// 按条码查看出库单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CodeList_Clicked(object sender, EventArgs e) {
            ServerHelp.SearchMethod(false, CodeList.Text);

            Navigation.PushAsync(new DetailPage());
        }
        /// <summary>
        /// 查看扫码数统计
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SCanTotal_Clicked(object sender, EventArgs e) {
            Navigation.PushAsync(new SCanTotalPage());
        }
        #endregion

        #region 退货管理
        /// <summary>
        /// 退货入库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputBtn_Clicked(object sender, EventArgs e) {

            OrderList.typename = ProduceManegeModel.OutputBtnName;
            OrderList.client_id = null;
            ServerHelp.ManageMethod(true, false, ProduceManegeModel.OutputBtnName, true,  true, false, true, false);
            
            Navigation.PushAsync(new WarehousePage()) ;
        }
        /// <summary>
        /// 查看退货单据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutputList_Clicked(object sender, EventArgs e) {
            ServerHelp.SearchMethod(false,  OutputList.Text);

            Navigation.PushAsync(new DetailPage());
        }

        #endregion

    }
}