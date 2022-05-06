using DeliverApp.View.MenuSettingView;
using DeliverApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuSettingPage : ContentPage
    {
        
        public MenuSettingPage()
        {
            InitializeComponent();


            
        }

        


     

        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            (sender as ListView).SelectedItem = null;

            if (args.SelectedItem != null)
            {
                MenuSettingViewModel pageData = args.SelectedItem as MenuSettingViewModel;
                Page page = (Page)Activator.CreateInstance(pageData.Type);
                await Navigation.PushAsync(page);
            }
        }
    }
}