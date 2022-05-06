using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.View.BarcodeReplaceView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BarcodeReplacePage : ContentPage
    {

        public BarcodeReplacePage()
        {
            InitializeComponent();

            MemoryName.Clicked += MemoryName_Clicked;





        }

    /// <summary>
    /// 替换记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
        private  void MemoryName_Clicked(object sender,EventArgs e ) { 

             Navigation.PushAsync(new BarcodeRecordPage());
        }
    }
}