using DeliverApp.Help;
using DeliverApp.Module;
using DeliverApp.Module.TableLists;
using DeliverApp.View.ManagementView;
using DeliverApp.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchPage : ContentPage
    {
       
        public SearchPage()
        {
            InitializeComponent();
           
          //  BindingContext =new SearchViewModel();
            Title = SearchModel.SearchPageTitel;
           
            lv_custormer.IsVisible = SearchModel.IsCustormerList;
            lv_location.IsVisible = SearchModel.IsLocationList;
            lv_store.IsVisible = SearchModel.IsStoreList;
            lv_product.IsVisible = SearchModel.IsProductList;
            lv_express.IsVisible  = SearchModel.IsExpressList;

            if ( SearchModel.Listview == true)
            {
                ListHeader.IsVisible = true;
            }
            else
            {
                ListHeader.IsVisible = false;
            }
            
            

            //显示结果
            GetResult();

        }
        /// <summary>
        /// 列表id
        /// </summary>
        public int  TitleListid { get; set; }



        public   async void GetResult()
        {
            
            if (SearchModel.SearchPageTitel == SearchModel.PageTitelClient) {
                //客户
                TitleListid = 0;

                //ServerHelp.ListViewMethod(true, false, false, false, false);
                lv_custormer.IsVisible = true;
                lv_location.IsVisible = false;
                lv_store.IsVisible = false;
                lv_product.IsVisible = false;
                lv_express.IsVisible = false;
                lv_custormer.ItemsSource = await SearchAsync(TitleListid);
              //  Total.Text="共" + SearchAsync(TitleListid).Result.Count.ToString()+"个客户";

            }
            else if (SearchModel.SearchPageTitel == SearchModel.PageTitelStor)
            {
                //仓库
                TitleListid = 1;

                lv_custormer.IsVisible = false;
                lv_store.IsVisible = true;
                lv_location.IsVisible = false;
                lv_product.IsVisible = false;
                lv_express.IsVisible = false;
                lv_store.ItemsSource = await SearchAsync(TitleListid);


            }
            else if (SearchModel.SearchPageTitel == SearchModel.PageTitelLocal)
           {
                //库位
                TitleListid = 2;
                lv_custormer.IsVisible = false;
                lv_store.IsVisible = false;
                lv_location.IsVisible = true;
                lv_product.IsVisible = false;
                lv_express.IsVisible = false;
                lv_location.ItemsSource = await SearchAsync(TitleListid);


            }
            else if (SearchModel.SearchPageTitel == SearchModel.PageTitelProduct)
            {
                //产品
                TitleListid = 3;
                lv_custormer.IsVisible = false;
                lv_store.IsVisible = false;
                lv_location.IsVisible = false;
                lv_product.IsVisible = true;
                lv_express.IsVisible = false;
                lv_product.ItemsSource = await SearchAsync(TitleListid);



            }
            else if (SearchModel.SearchPageTitel == SearchModel.PageTitelExpress)
            {
                //快递
                TitleListid = 4;
                lv_custormer.IsVisible = false;
                lv_store.IsVisible = false;
                lv_location.IsVisible = false;
                lv_product.IsVisible = false;
                lv_express.IsVisible = true;
                lv_express.ItemsSource = await SearchAsync(TitleListid);

            }

        }

     


        /// <summary>
        /// 列表数据获取
        /// </summary>
        /// <returns></returns>
        private  async Task<List<MessageList>> SearchAsync(int seleceid) {
             List<MessageList> result = new List<MessageList>();
            try
            {
                HttpClient client = new HttpClient();
                if (seleceid == 0)
                {
                    //客户数据表
                     client.BaseAddress = new Uri(Global.Url + Global.GetCustormersList);
                 
                }
                else if (seleceid == 1)
                {
                    //仓库数据表
                    client.BaseAddress = new Uri(Global.Url + Global.GetStoreList);

                } else if (seleceid == 2) {
                    //库位数据表
                    client.BaseAddress = new Uri(Global.Url + Global.GetLocationList);

                } else if(seleceid==3){
                    //产品数据表
                    client.BaseAddress = new Uri(Global.Url + Global.GetProductList);
                }
                else if (seleceid == 4)
                {
                    //快递数据表
                    client.BaseAddress = new Uri(Global.Url + Global.GetExpressList);

                }
             
                HttpResponseMessage resp = await client.GetAsync(client.BaseAddress);
                var res = await resp.Content.ReadAsStringAsync();
                 result = JsonConvert.DeserializeObject<List<MessageList>>(res);
                Console.WriteLine(result.Count);
                if (seleceid == 0)
                {
                    Total.Text = "共 " + result.Count.ToString() + " 个客户";
                }
                else if (seleceid == 1)
                {
                    Total.Text = "共 " + result.Count.ToString() + " 个仓库";
                }
                else if (seleceid == 2)
                {
                    Total.Text = "共 " + result.Count.ToString() + " 个库位";
                }
                else if (seleceid == 3)
                {
                    Total.Text = "共 " + result.Count.ToString() + " 个产品";
                }
                else if (seleceid == 4)
                {
                    Total.Text = "共 " + result.Count.ToString() + " 快递公司";
                }

            }
            catch (Exception ex)
            {
               Console.WriteLine(ex);
            }
                return result; 
        }
     

        #region 客户
        public EventHandler<string> CustormersValue;
        //lv_custormers_selection
        public void lv_custormers_selection(object sender, EventArgs e)
        {

            var res = lv_custormer.SelectedItem as MessageList;
            Console.WriteLine(res.Id);
            var _CustormersValue = res.Id + " " + res.Name;
            OrderList.client_id = res.Id;
            OrderList.store_id = null;
            //返回时，触发事件
            EventHandler<string> handler = CustormersValue;
            if (handler != null)
            {
                //返回值数据
                handler(this, _CustormersValue);
            }

            //选择
            lv_custormer.SelectedItem = res;
            //返回上一页
            Navigation.PopAsync();

        }
        #endregion
        #region 仓库
        ///lv_store_selection
        ///
        public EventHandler<string> StoreValue;
        public void lv_store_selection(object sender, EventArgs e)
        {

            var res = lv_store.SelectedItem as MessageList;
            Console.WriteLine(res.Id);
            var _StoreValue = res.Id + " " + res.Name;
            OrderList.store_id = res.Id;
            OrderList.client_id = null;
            CodeList.CustormerId = res.Id;

            //返回时，触发事件
            EventHandler<string> handler = StoreValue;
            if (handler != null)
            {
                //返回值数据
                handler(this, _StoreValue);
            }

            //选择
            lv_store.SelectedItem = res;
            //返回上一页
            Navigation.PopAsync();

        }

        #endregion
        #region 库位
        //lv_location_selection
        public EventHandler<string> LocationValue;
        public void lv_location_selection(object sender, EventArgs e)
        {

            var res = lv_location.SelectedItem as MessageList;
            Console.WriteLine(res.Id);
            var _LocationValue = res.Id + " " + res.Name;
            CodeList.LocationId = res.Id;

            //返回时，触发事件
            EventHandler<string> handler = LocationValue;
            if (handler != null)
            {
                //返回值数据
                handler(this, _LocationValue);
            }

            //选择
            lv_location.SelectedItem = res;
            //返回上一页
            Navigation.PopAsync();

        }
        #endregion
        #region 产品
        //lv_product
        public EventHandler<string> ProductValue;
        public void lv_product_selection(object sender, EventArgs e)
        {

            var res = lv_product.SelectedItem as MessageList;
            Console.WriteLine(res.Id);
            var _ProductValue = res.Id + " " + res.Name;
            CodeList.ProductId = res.Id;

            //返回时，触发事件
            EventHandler<string> handler = ProductValue;
            if (handler != null)
            {
                //返回值数据
                handler(this, _ProductValue);
            }

            //选择
            lv_product.SelectedItem = res;
            //返回上一页
            Navigation.PopAsync();

        }
        #endregion

        #region 快递
        //lv_express
        public EventHandler<string> ExpressValue;
        public void lv_express_selection(object sender, EventArgs e)
        {

            var res = lv_express.SelectedItem as MessageList;
            Console.WriteLine(res.Id);
            var _ExpressValue = res.Id + " " + res.Name;
           

            //返回时，触发事件
            EventHandler<string> handler = ExpressValue;
            if (handler != null)
            {
                //返回值数据
                handler(this, _ExpressValue);
            }

            //选择
            lv_express.SelectedItem = res;
            //返回上一页
            Navigation.PopAsync();

        }
        #endregion
    }
}