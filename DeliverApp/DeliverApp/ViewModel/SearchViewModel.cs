using DeliverApp.Module;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;

namespace DeliverApp.ViewModel
{
    public class SearchViewModel 
    {
        public IList<MessageList> messageListsdata { get; set; }
        public SearchViewModel()
        {
            try
            {
                messageListsdata = new ObservableCollection<MessageList>();
                GetMessage();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void GetMessage()
        {
            try {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://192.168.3.12:45091/api/ClientsList/GetList");
                
                var resp = await client.GetAsync(client.BaseAddress);
                var res = await resp.Content.ReadAsStringAsync();
                if (res != null)
                {
                    messageListsdata = (IList<MessageList>)resp;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
