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

namespace DeliverApp.View.MenuSettingView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DefaultSettingPage : ContentPage
    {
        public DefaultSettingPage()
        {
            InitializeComponent();
            
            
        }

        private void Label_BindingContextChanged(object sender, EventArgs e)
        {

        }

        #region
        /// <summary>
        /// 仓库选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void WarehouseSelection_Tapped(object sender, EventArgs e) {

            ServerHelp.SearchMethod(true, SearchModel.PageTitelStor);

            await Navigation.PushAsync(new SearchPage());
        }

        /// <summary>
        /// 库位选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void LocationSelection_Tapped(object sender, EventArgs e) {

            ServerHelp.SearchMethod(true, SearchModel.PageTitelLocal);

            await Navigation.PushAsync(new SearchPage());
        }
        /// <summary>
        /// 经销商选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ClientSelection_Tapped(object sender, EventArgs e)
        {

            ServerHelp.SearchMethod(true,SearchModel.PageTitelClient);
            await Navigation.PushAsync(new SearchPage());
        }
        /// <summary>
        /// 产品代码选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ProductSelection_Tapped(object sender, EventArgs e)
        {

            ServerHelp.SearchMethod( true,  SearchModel.PageTitelProduct);

            await Navigation.PushAsync(new SearchPage());
        }
        /// <summary>
        /// 快递公司选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void ExpressSelection_Tapped(object sender, EventArgs e)
        {

            ServerHelp.SearchMethod(true, SearchModel.PageTitelExpress);
            await Navigation.PushAsync(new SearchPage());
        }
        #endregion
    }
}