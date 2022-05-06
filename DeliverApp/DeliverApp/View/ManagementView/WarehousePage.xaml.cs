using DeliverApp.Help;
using DeliverApp.Module;
using DeliverApp.Module.TableLists;
using DeliverApp.View.MenuSettingView;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.View.ManagementView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WarehousePage : ContentPage, INotifyPropertyChanged
    {
        public WarehousePage()
        {
            InitializeComponent();
            Title = WarehouseModel.WarehousePageTitle;
            SeleteClients.IsVisible = WarehouseModel.IsSeleteClients;
            SeleteStor.IsVisible = WarehouseModel.IsSeleteStor;
            SeleteClientsName.Clicked += SeleteClients_Clicked;
            SeleteStorName.Clicked += SeleteStorName_Clicked;
            NextBtn.Clicked += NextBtn_Clicked;
            AutomaticName.Clicked += AutomaticName_Clicked;
            GetGoodsId();
            GenerateOrderModel.OrderTitleName = OrderText.Text;
            if (SeleteClients.IsVisible == true)
            {
                SeleteStorName.Text = null;

            }
            else {
                SeleteClientsName.Text = null;
            }



        }

        public static string TimeString = DateTime.Now.ToString("yyyyMMdd");
        public static int Num = 0;
        public static string Result;

        /// <summary>
        /// 机器代码
        /// </summary>
        public static string MachineCode = CompanySettingPage.MachineCodeDefaul;

        /// <summary>
        /// 自动生成
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private void AutomaticName_Clicked(object senders, EventArgs e)
        {
            GetGoodsId();
        }

        public void GetGoodsId()
        {
            GetGoodNum();
            OrderText.Text = MachineCode + TimeString + Result;
            OrderList.order_id = OrderText.Text;
        }
        /// <summary>
        /// 单号
        /// </summary>
        public static  void GetGoodNum() {

            
            var sum = Num + 1;
            Num = sum;
            //Random random = new Random();
            //var num = random.Next(0, 9999);
            if (Num < 1000 && Num >= 100)
            {
                Result = "0" + Num;


            }
            else if (Num < 100 && Num >= 10)
            {
                Result = "00" + Num;
            }
            else if (Num < 10)
            {
                Result = "000" + Num;
            }
            else
            {
                Result = Num.ToString();
            }
        }

      

        private void OrderEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            OrderText.Text = ((Entry)sender).Text;
            OrderList.order_id = OrderText.Text;

        }

        /// <summary>
        /// 选择顾客
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private  void SeleteClients_Clicked(object senders, EventArgs e)
            {

            ServerHelp.SearchMethod( true, SearchModel.PageTitelClient);

            var page = new SearchPage();
            //跳转到下一页时，订阅SearchPage的事件
            page.CustormersValue += (sender , ex) =>
            {
                //赋值给SeleteClientsName.Text
                SeleteClientsName.Text = ex;
            };
            Navigation.PushAsync(page);
            }



        /// <summary>
        /// 选择仓库
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private void SeleteStorName_Clicked(object senders, EventArgs e)
            {
            ServerHelp.SearchMethod( true,  SearchModel.PageTitelStor);
            var page = new SearchPage();
            //跳转到下一页时，订阅SearchPage的事件
            page.StoreValue += (sender, ex) =>
            {
                //SeleteStorName.Text
                SeleteStorName.Text = ex;
            };
            Navigation.PushAsync(page);


        }

      


        /// <summary>
        /// 下一步
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private async void NextBtn_Clicked(object senders, EventArgs e)
            {


            if (string.IsNullOrWhiteSpace(OrderText.Text)) {
                ErrorMessage.Text = "请输入订单号";
            }
            else if (SeleteStorName.Text == "请选择仓库")
            {
                ErrorMessage.Text = SeleteStorName.Text;


            }
           else if (SeleteClientsName.Text == "请选择客户") {
                ErrorMessage.Text = SeleteClientsName.Text;
            }
            else
            {
                
                    Goods goods = new Goods()
                    {
                        GoodsId = OrderList.order_id,
                        CustormerId = OrderList.client_id,
                        StoreId = OrderList.store_id,
                        CreateTime = CreateTime.Date,
                        TypeName = OrderList.typename
                    };
                    await CreateGoodsAsync(goods);
                
               
            }
               
            }
        /// <summary>
        /// 生成入库单号
        /// </summary>
        /// <param name="goodsList"></param>
        /// <returns></returns>
        public async Task CreateGoodsAsync(Goods goods) {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.Url+ Global.InsertGoods);
                //序列化
                string jsonData = JsonConvert.SerializeObject(goods);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                //反序列化
                var result = JsonConvert.DeserializeObject<GoodsList>(res);

                Console.WriteLine(result.CustormerId);
                //生成单号成功时，跳转到下一步
                if (result.CustormerId != null || result.StoreId != null)
                {
                    
                        await Navigation.PushAsync(new GenerateOrderPage()
                        {
                            Title =  WarehouseModel.WarehousePageTitle
                        }); ;
                    
                       
                }
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
                ErrorMessage.Text = "生成单号失败！";
            }
                
           
        }



        }
    }
