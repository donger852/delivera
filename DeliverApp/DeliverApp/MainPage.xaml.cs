using DeliverApp.Help;
using DeliverApp.Module;
using DeliverApp.View;
using DeliverApp.View.BarcodeReplaceView;
using DeliverApp.View.LoginView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ZXing.Mobile;

namespace DeliverApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

          //  OperationName.Clicked += Operation_Clicked;
           // OfflineName.Clicked += Offline_Clicked;

            Current_Login.Clicked += Current_Login_Clicked;
            //直接页面跳转 
            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;


        }
        public ICommand NavigateCommand { private set; get; }
       private async void Current_Login_Clicked (object sender, EventArgs e)
        {
            await Navigation.PushAsync( new SelectCampanyPage());
        }

       


        /// <summary>
        /// 入库管理
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        public async void Input_Clicked( object senders,EventArgs e) {

            ServerHelp.SelectManageMethod(true, false, false,InputName.Text);
            await Navigation.PushAsync(new ProductManagePage());
        }

        /// <summary>
        /// 退货管理
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        
        public async void Output_Clicked(object senders, EventArgs e)
        {
           
            ServerHelp.SelectManageMethod(false, false, true, OutputName.Text);
            await Navigation.PushAsync(new ProductManagePage());
        }
        /// <summary>
        /// 发货管理
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>

        public async void Send_Clicked(object senders, EventArgs e) {

            ServerHelp.SelectManageMethod(false, true, false, SendName.Text);
            await Navigation.PushAsync(new ProductManagePage());
        }
        /// <summary>
        /// 离线数据管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Offline_Clicked(object sender, EventArgs e)
        //{
        //    ServerHelp.SearchMethod(false, "", OfflineName.Text);
        //    Navigation.PushAsync(new SearchPage());
        //}
        /// <summary>
        /// 操作日志管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Operation_Clicked(object sender, EventArgs e) {
        //    ServerHelp.SearchMethod( false,"", OperationName.Text);
        //     Navigation.PushAsync(new SearchPage());
        //}



        /// <summary>
        /// 设置按钮
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        public async void Setting_Clicked(object senders, EventArgs e) {

            await Navigation.PushAsync(new MenuSettingPage()
            {
                Title = Setting.Text
            }) ;
        }

      

        
    }
}
