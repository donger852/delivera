using DeliverApp.Module;
using DeliverApp.Module.TableLists;
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
using ZXing.Mobile;

namespace DeliverApp.View.LoginView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
     
        public LoginPage()
        {
            InitializeComponent();
            LoginBut.Clicked += LoginBtn_Clicked;
            Url.Text = UserInfo.Url;
            UserName.Text = UserInfo.UserName;
            Password.Text = UserInfo.Password;
            
        }

        private async void SwitchCompany_Clicked(object senders, EventArgs e)
        {
            var scanner = new MobileBarcodeScanner(); 

            var result = await scanner.Scan();
            var npm = result.Text;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="senders"></param>
        /// <param name="e"></param>
        private void LoginBtn_Clicked(object senders, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Url.Text) && !string.IsNullOrWhiteSpace(UserName.Text) && !string.IsNullOrWhiteSpace(Password.Text))
            {
                LoginAsync();

            }
            else {
                ValidateMsg.Text = "请输入完整信息";
            }

        }

        private async Task LoginAsync() {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(Url.Text + Global.PostSelectUser+"?UserName=" + UserName.Text + "&Url=" + Url.Text + "&Password=" + Password.Text);
                HttpResponseMessage resp = await client.GetAsync(client.BaseAddress);
                var res = await resp.Content.ReadAsStringAsync();
                if (res != null)
                {
                    if (res == "true")
                    {
                        Global.Url = Url.Text;
                        UserInfo.Url = Url.Text;
                        UserInfo.UserName=UserName.Text;
                        UserInfo.Password=Password.Text;
                        var LogintypeName = Logintype.LogintypeName;
                        if (LogintypeName==0)
                        {
                            UserDetail userdetail = new UserDetail()
                            {
                                UserName = UserInfo.UserName,
                                LoginType = 2
                            };
                          await  SetUserType(userdetail);
                        }
                        else if (LogintypeName == 1)
                        {
                            UserDetail userdetail = new UserDetail()
                            {
                                UserName = UserInfo.UserName,
                                LoginType = 1
                            };
                        await   SetUserType(userdetail);
                        }
                      
                       await Navigation.PushAsync(new MainPage());
                    }
                    else
                    {
                        ValidateMsg.Text = "用户信息错误";
                    }
                }
                else {
                    ValidateMsg.Text = "服务地址出错!";
                }
            }
            catch (Exception ex) {
                ValidateMsg.Text = "服务地址出错!";
            } 
        }

        private async Task SetUserType(UserDetail userdetail)
        {
            try
            {
                HttpClient client = new HttpClient();

                client.BaseAddress = new Uri(Url.Text + Global.SetUserType);
                string jsonData = JsonConvert.SerializeObject(userdetail);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(client.BaseAddress, content);

                var res = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}