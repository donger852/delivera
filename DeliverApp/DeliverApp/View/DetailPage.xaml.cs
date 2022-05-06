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

namespace DeliverApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        public DetailPage()
        {
            InitializeComponent();
            getLvGoods();
        }


        public async void getLvGoods() {
            lv_goods.ItemsSource = await GetNormalWarehouseListAsync();


        }

        public async Task<List<Code>> GetNormalWarehouseListAsync( )
        {
        List<Code> result = new List<Code>();
        try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(Global.Url + "/api/FreeSqlList/GetNormal_WarehousingList");
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress);
                var res = await response.Content.ReadAsStringAsync();
                //反序列化
                 result = JsonConvert.DeserializeObject<List<Code>>(res);
                TotalNum.Text="共"+ result.Count.ToString()+"单";
                Console.WriteLine(result.Count);

               
                //生成单号成功时，跳转到下一步

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
               
            }
            
        return result;


        }
    }
}