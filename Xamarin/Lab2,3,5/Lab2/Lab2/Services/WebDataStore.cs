using Lab2.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

//[assembly: Xamarin.Forms.Dependency(typeof(Lab2.Services.WebDataStore))]
namespace Lab2.Services
{
    class WebDataStore : IDataStore<Stationery>
    {

        const string Url = "http://192.168.0.105:63864/api/Stationery";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<bool> AddItemAsync(Stationery item)
        {
            HttpClient client = GetClient();
            var response = await client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(item),
                    Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            HttpClient client = GetClient();
            var response = await client.DeleteAsync(Url + "/" + id);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }

        public async Task<Stationery> GetItemAsync(int id)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url + "/" + id);
            return JsonConvert.DeserializeObject<Stationery>(result);
        }

        public async Task<IEnumerable<Stationery>> GetItemsAsync(bool forceRefresh = false)
        {
            HttpClient client = GetClient();
            string result = await client.GetStringAsync(Url);
            return JsonConvert.DeserializeObject<IEnumerable<Stationery>>(result);
        }

        public async Task<bool> UpdateItemAsync(Stationery item)
        {
            HttpClient client = GetClient();
            var response = await client.PutAsync(Url + "/" + item.Id,
                new StringContent(
                    JsonConvert.SerializeObject(item),
                    Encoding.UTF8, "application/json")
                    );
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return await Task.FromResult(false);
            }
            return await Task.FromResult(true);
        }
    }
}
