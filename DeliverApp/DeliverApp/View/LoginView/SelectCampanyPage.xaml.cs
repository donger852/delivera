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

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.View.LoginView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectCampanyPage : ContentPage
    {
        public SelectCampanyPage()
        {
            InitializeComponent();
            SelectCampanyModel.ManageImage = ManageImage;
            Manage.IconImageSource = SelectCampanyModel.ManageImage;
            Manage.Clicked += Manage_Clicked;
            LoginBtn.Clicked += LoginBtn_Clicked;
            //默认样式
            ServerHelp.SelectCampanyMethod(true, false, true, false);
            DefaultList.IsVisible = SelectCampanyModel.IsDefaultList;
            DelectList.IsVisible = SelectCampanyModel.IsDelectList;
            AllInsertBtn.IsVisible = SelectCampanyModel.IsAllInsertBtn;
            AllDelectBtn.IsVisible = SelectCampanyModel.IsAllDelectBtn;

            GetResult();

        }

        public string ManageImage = "manage.png";
        public string FinishImage = "finish.png";



        public async void GetResult() {
            DefaultList.ItemsSource = await SelectLoginUser();
            DelectList.ItemsSource = await SelectLoginUser();
        }


        /// <summary>
        /// 右上角管理按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Manage_Clicked (object sender,EventArgs e)
        {
            if (SelectCampanyModel.ManageImage == FinishImage)
            {
                SelectCampanyModel.ManageImage = ManageImage;
                Manage.IconImageSource = SelectCampanyModel.ManageImage;
                IsVisibleMethod(true, false, false, true);

            }
            else if (SelectCampanyModel.ManageImage == ManageImage)
            {
                SelectCampanyModel.ManageImage = FinishImage;
                Manage.IconImageSource = SelectCampanyModel.ManageImage;
                IsVisibleMethod(false, true, true, false);
            }
        }

        /// <summary>
        /// 添加绑定
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoginBtn_Clicked (object sender, EventArgs e)
        {
            Logintype.LogintypeName = 1;
          await Navigation.PushAsync(new LoginPage());

        }

        private async Task<List<UserInfo>> SelectLoginUser()
        {
            List<UserInfo> result = new List<UserInfo>();
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(Global.Url + Global.SelectLoginUser);
                HttpResponseMessage resp = await client.GetAsync(client.BaseAddress);
                var res = await resp.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<UserInfo>>(res);
            }catch (Exception ex)
            {
                Console.WriteLine("列表出错");
            }
            return result;
        }






        /// <summary>
        /// 页面样式
        /// </summary>
        /// <param name="isdefaultlist">显示默认列表样式</param>
        /// <param name="isdelectlist">管理列表样式</param>
        /// <param name="isallinsertbtn">批量导入</param>
        /// <param name="isalldelectbtn">一键删除</param>
        public void IsVisibleMethod(bool isdefaultlist, bool isdelectlist, bool isallinsertbtn, bool isalldelectbtn)
        {
            DefaultList.IsVisible = isdefaultlist;
            DelectList.IsVisible = isdelectlist;
            AllInsertBtn.IsVisible = isallinsertbtn;
            AllDelectBtn.IsVisible = isalldelectbtn;
            ServerHelp.SelectCampanyMethod(isdefaultlist, isdelectlist, isallinsertbtn, isalldelectbtn);

        }
    }
}