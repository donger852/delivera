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
    public partial class VerifySettingPage : ContentPage
    {
        public VerifySettingPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 上传模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // I want to get an index of the list item here.
        }
    }
}