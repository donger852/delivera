using DeliverApp.Module;
using DeliverApp.Module.TableLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DeliverApp.Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatadaseTestPage : ContentPage
    {
        public DatadaseTestPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            collectionView.ItemsSource = await App.Database.GetExpressListAsync();
        }
        async void OnButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) && !string.IsNullOrWhiteSpace(ageEntry.Text))
            {
                await App.Database.SaveExpressListAsync(new ExpressList
                {
                    //Name = nameEntry.Text,
                    //   Age = int.Parse(ageEntry.Text)
                    Number = ageEntry.Text,
                });

                nameEntry.Text = ageEntry.Text = string.Empty;
                collectionView.ItemsSource = await App.Database.GetExpressListAsync();
            }
            
        }
    }
}