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
    public partial class UpdatingPage : ContentPage
    {
        public UpdatingPage()
        {
            InitializeComponent();
        }
        #region 数据更新
       
        /// <summary>
        /// 产品数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Proup_Clicked(object sender, EventArgs e)
        {

            Putting.Text = "产品更新完成，共" + ProNum.Text + "条！";
        }
        /// <summary>
        /// 仓库数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Store_Clicked(object sender, EventArgs e)
        {

            Putting.Text = "仓库更新完成，共" + StoNum.Text + "条！";
        }
        /// <summary>
        /// 库位数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Locat_Clicked(object sender, EventArgs e)
        {

            Putting.Text = "库位更新完成，共" + LocatNum.Text + "条！";
        }
        /// <summary>
        /// 客户数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Client_Clicked(object sender, EventArgs e)
        {

            Putting.Text = "客户更新完成，共" + ClientNum.Text + "条！";
        }
        /// <summary>
        /// 快递数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Exp_Clicked(object sender, EventArgs e)
        {

            Putting.Text = "快递更新完成，共" + ExpNum.Text + "条！";
        }
        #endregion
    }
}