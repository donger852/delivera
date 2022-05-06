using DeliverApp.Test.Module;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DeliverApp.Test.Service
{
    public class RestService
    {
        HttpClient _client;

        public RestService()
        {
            _client = new HttpClient();

        }


        


        public async Task<List<Repository>> GetRepositoriesAsync(string uri)
        {
           
            List<Repository> repositories = null;
            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    repositories = JsonConvert.DeserializeObject<List<Repository>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\tERROR {0}", ex.Message);
            }

            return repositories;
        }
    }
}
