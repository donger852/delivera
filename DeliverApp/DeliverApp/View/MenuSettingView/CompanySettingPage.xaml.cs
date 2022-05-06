using DeliverApp.Module;
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
    public partial class CompanySettingPage : ContentPage
    {
      

        public CompanySettingPage()
        {
            InitializeComponent();
            
            MachineCode.Text = CompanySettingModel.MachineCodeDefaul;


        }
        /// <summary>
        /// 机器代码
        /// </summary>
        public static string MachineCodeDefaul = CompanySettingModel.MachineCodeDefaul;

        /// <summary>
        /// 单号规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            var text = "自动编号";
            Lab.Text = e.Value ? $"{text}" : @"";
        }
    }
}