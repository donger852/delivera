using DeliverApp.Help;
using DeliverApp.Module;
using DeliverApp.Module.TableLists;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;

namespace DeliverApp.View.ManagementView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenerateOrderPage : ContentPage
    {
        public GenerateOrderPage()
        {
            InitializeComponent();

            
            OrderTitle.Text = OrderList.order_id;
            IsOnStock.IsVisible = GenerateOrderModel.IsOnStockActive;
            IsSelectProduct.IsVisible = GenerateOrderModel.IsSelectProductAvtive;
            IsSelectPlace.IsVisible = GenerateOrderModel.IsSelectPlaceActive;
            IsSelectClient.IsVisible = GenerateOrderModel.IsSelectClientActive;
            IsSelectCreate.IsVisible = GenerateOrderModel.IsSelectCreateActive;
            SelectProduct.Clicked += SelectProduct_Clicked;
            SelectPlace.Clicked += SelectPlace_Clicked;
            SelectClient.Clicked += SelectClient_Clicked;

            Scan.Clicked += Scan_Clicked;
            FinishBtn.Clicked += FinishBtn_Clicked;

            //失败数量初始值赋值为 0
            failinit = 0;
        }
        /// <summary>
        /// 失败数量初始值
        /// </summary>
        public static int failinit { get; set; }

        public static int successcount { get; set; }
        private MobileBarcodeScanner scanner;

        #region 条码信息

        /// <summary>
        /// 选择产品
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private void SelectProduct_Clicked (object senders, EventArgs e)
        {
            ServerHelp.SearchMethod(true,  SearchModel.PageTitelProduct);
            var  page = new SearchPage();
            page.ProductValue+= (sender, ex) =>
            {
                //赋值给SelectProduct.Text
                SelectProduct.Text = ex;
            };
            Navigation.PushAsync(page);
        }
        ///选择库位
        private  void SelectPlace_Clicked(object senders, EventArgs e)
        {

            ServerHelp.SearchMethod(true, SearchModel.PageTitelLocal);
            var page = new SearchPage();

            page.LocationValue += (sender, ex) =>
            {
                //赋值给SelectPlace.Text
                SelectPlace.Text = ex;
            };
            Navigation.PushAsync(page);
        }
        /// <summary>
        /// 选择客户
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private  void SelectClient_Clicked(object senders, EventArgs e)
        {

            ServerHelp.SearchMethod(true, SearchModel.PageTitelClient);

            var page = new SearchPage();

            page.CustormersValue += (sender, ex) =>
            {
                //赋值给SelectClient.Text
                SelectClient.Text = ex;
            };
            Navigation.PushAsync(page);
        }

        /// <summary>
        /// 批号输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            lotnum.Text = ((Entry)sender).Text;

        }
        #endregion

        #region 确定条码
        /// <summary>
        /// 确定条码
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        public async void CheckBtn_Clicked(object senders, EventArgs e) {
            //正常入库时
            if (OrderList.typename == ProduceManegeModel.InputBtnName)
            {
                
                if (SelectPlace.Text == "请选择库位")
                {
                    ErrorText.Text = "请选择库位";
                }
                else if (SelectProduct.Text == "请选择产品")
                {
                    ErrorText.Text = "请选择产品";
                }
                else if (string.IsNullOrWhiteSpace(lotnum.Text))
                {
                    ErrorText.Text = "请输入生产批号";
                }
                else if (string.IsNullOrWhiteSpace(CodeName.Text))
                {
                    ErrorText.Text = "请输入商品条码";
                }
                else
                {
                    Code code = new Code()
                    {
                        CodeId = CodeName.Text,
                        ProductId = CodeList.ProductId,
                        LocationId = CodeList.LocationId,
                        CustormerId = CodeList.CustormerId,
                        GoodsId = OrderList.order_id,
                        CodeTime = datatime.Date,
                        Lotnum = lotnum.Text
                    };

                    await CreateCodeAsync(code);
                    Code code1 = new Code()
                    {
                        GoodsId = OrderList.order_id
                    };
                    lv_code.ItemsSource = await GetCodeGoodidListAsync(code1);

                    Fail.Text = "失败：" + failinit.ToString();
                    var totalcount = failinit + successcount;
                    Counts.Text = "总数："+totalcount.ToString();
                }
            }
            //已入库产品发货
            else if (OrderList.typename == ProduceManegeModel.OnStockName) {

                if (string.IsNullOrWhiteSpace(CodeName.Text))
                {
                    ErrorText.Text = "请输入商品条码";
                }
                else { 
                Code code = new Code() { 
                    CodeId = CodeName.Text,
                    GoodsId = OrderList.order_id,
                };
                await SetCodeIdInUpdate(code);
                Code code1 = new Code()
                {
                    GoodsId = OrderList.order_id
                };
                lv_code.ItemsSource = await GetCodeGoodidListAsync(code1);
                Fail.Text = "失败："+failinit.ToString();
                var  totalcount = failinit + successcount;
                    Counts.Text = "总数:"+totalcount.ToString();
                }
            }
            //不入库直接发货
            else if (OrderList.typename == ProduceManegeModel.UnStorgeName)
            {
                if (SelectProduct.Text == "请选择产品")
                {
                    ErrorText.Text = "请选择产品";
                }
                else if(string.IsNullOrWhiteSpace(CodeName.Text))
                {
                    ErrorText.Text = "请输入商品条码";
                }
                else
                {
                    Code code = new Code()
                    {
                        CodeId = CodeName.Text,
                        GoodsId = OrderList.order_id,
                        ProductId = CodeList.ProductId,
                        Lotnum = lotnum.Text,
                        CodeTime = datatime.Date
                    };
                    await CreateCodeAsync(code);
                    Code code1 = new Code()
                    {
                        GoodsId = OrderList.order_id
                    };
                    lv_code.ItemsSource = await GetCodeGoodidListAsync(code1);

                    Fail.Text = "失败：" + failinit.ToString();
                    var totalcount = failinit + successcount;
                    Counts.Text = "总数：" + totalcount.ToString();
                }
            }
            //退货入库
            else if (OrderList.typename == ProduceManegeModel.OutputBtnName)
            {

                if (SelectPlace.Text == "请选择库位")
                {
                    ErrorText.Text = "请选择库位";
                }
                else if (SelectClient.Text== "请选择客户")
                {
                    ErrorText.Text = "请选择客户";
                }
                else
                {

                   
                    Code code = new Code()
                    {
                        CodeId = CodeName.Text,
                        GoodsId = OrderList.order_id,
                        LocationId = CodeList.LocationId,
                        CustormerId = CodeList.CustormerId,
                    };
                  await  SelectCodeIdOnStockUpdate(code);

                    Code code1 = new Code()
                    {
                        GoodsId = OrderList.order_id
                    };
                    //获取成功导入列表
                    lv_code.ItemsSource = await GetCodeGoodidListAsync(code1);

                    Fail.Text = "失败：" + failinit.ToString();
                    var totalcount = failinit + successcount;
                    Counts.Text = "总数：" + totalcount.ToString();
                }
            }

        }
#endregion

        protected override async void OnAppearing()
        {
            base.OnAppearing();

        }
        #region 底部按钮事件
        /// <summary>
        /// 完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FinishBtn_Clicked(object sender, EventArgs e)
        {
            var res = await DisplayAlert("", "完成", "确定", "取消");
            if (res)
            {
                await Navigation.PopAsync();

            }
        }

        private async void Scan_Clicked(object sender, EventArgs e)

        {
            var scanner = new MobileBarcodeScanner();
            
            var result = await scanner.Scan();
            CodeName.Text = result.Text;
            //if (!string.IsNullOrEmpty(result.Text))
            //{
            //    ScanResultHandle(result);
            //}

        }

        /// <summary>
        /// 获取扫描结果的处理
        /// </summary>
        private void ScanResultHandle(ZXing.Result result)
        {
            string url = result.Text;
            if (!string.IsNullOrEmpty(url))
            {
                CodeName.Text =result.Text;
            }
            else
            {
                ErrorText.Text = "扫描取消";
            }
        }
        #endregion

        #region API获取数据信息


        #region 按CodeId查询不入库直接发货或已入库发货
        /// <summary>
        /// 按CodeId查已入库产品发货
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task SelectCodeIdOnStockUpdate(Code code)
        {
            try
            {
                var client = new HttpClient();
                    client.BaseAddress = new Uri(Global.Url + Global.SelectCodeIdOnStockUpdate);

                //序列化
                string jsonData = JsonConvert.SerializeObject(code);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                if (res == "true")
                {
                    await SetCodeIdInUpdate(code);
                    ErrorText.Text = CodeName.Text + "成功";
                    ErrorText.TextColor = Color.Green;
                }
                else
                {
                   await SelectCodeIdUnStockUpdate(code);
                }
            }
            catch (Exception ex)
            {

            }
        }
        
        /// <summary>
        /// 按CodeId查询不入库直接发货
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task SelectCodeIdUnStockUpdate(Code code)
        {
            try
            {
                var client = new HttpClient();
               client.BaseAddress = new Uri(Global.Url + Global.SelectCodeIdUnStorgeUpdate);
                //序列化
                string jsonData = JsonConvert.SerializeObject(code);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                if (res == "true")
                {
                    await SetCodeIdInUpdate(code);

                }
                else
                {
                    ErrorText.Text = CodeName.Text + "不存在";
                    ErrorText.TextColor = Color.Red;
                    var failcount = failinit + 1;
                    failinit = failcount;
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
        #region 生成条码单
        /// <summary>
        /// 生成条码单
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        public async Task<List<Code>> CreateCodeAsync(Code code)
        {
            List<Code> result = new List<Code>(); 
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.Url + Global.InsertCode);
                //序列化
                string jsonData = JsonConvert.SerializeObject(code);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode) {
                    ErrorText.Text = CodeName.Text + "成功";
                    ErrorText.TextColor = Color.Green;

                }
                else
                {
                    ErrorText.Text = CodeName.Text + "重复";
                    ErrorText.TextColor = Color.Red;
                    var failcount = failinit + 1;
                    failinit = failcount;
                }
            }
            catch (Exception ex)
            {
                ErrorText.Text = CodeName.Text + "重复";
                ErrorText.TextColor = Color.Red;

                var failcount = failinit + 1;
                failinit = failcount;

            }
            return result;

        }
        #endregion
        #region 根据单号获取条码列表
        /// <summary>
        /// 根据单号获取条码列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<List<Code>> GetCodeGoodidListAsync(Code code)
        {
            List<Code> result = new List<Code>();
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.Url + Global.PostCodeGoodidList);
                
                //序列化
                string jsonData = JsonConvert.SerializeObject(code);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                //反序列化
                result = JsonConvert.DeserializeObject<List<Code>>(res);
                
                 await  GetGoodsIdCodeCount(code);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return result;

        }
        #endregion
        #region 根据单号获取条码列表总数
        /// <summary>
        ///根据单号获取条码列表总数
        /// </summary>
        public async Task<int> GetGoodsIdCodeCount(Code code)
        {
            int result = 0;
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.Url+ Global.GetGoodsIdCodeCount);

                //序列化
                string jsonData = JsonConvert.SerializeObject(code);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                //反序列化
                 result = JsonConvert.DeserializeObject<int>(res);
               
                Success.Text ="成功："+ result.ToString();
                
                successcount = result;



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return result;

        }
        #endregion
        #region 更新条码goodid
        /// <summary>
        /// 更新条码goodid
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public async Task<List<Code>> SetCodeIdInUpdate(Code code)
        {
            List<Code> result = new List<Code>();
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.Url + Global.SetCodeIdInUpdate);

                //序列化
                string jsonData = JsonConvert.SerializeObject(code);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
                if (res == "1")
                {
                    ErrorText.Text = CodeName.Text + "成功";
                    ErrorText.TextColor = Color.Green;
                }
                else {
                    ErrorText.Text = CodeName.Text + "不存在";
                    ErrorText.TextColor = Color.Red;
                    var failcount = failinit + 1;
                    failinit = failcount;
                }
                    
                await GetGoodsIdCodeCount(code);
            }
            catch (Exception ex)
            {
                ErrorText.Text = CodeName.Text + "不存在";
                ErrorText.TextColor = Color.Red;
                var failcount = failinit + 1;
                failinit = failcount;

            }
            return result;

        }
        #endregion

        #endregion
    }
}