using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using CarStore.ApiClient.Models;
using Newtonsoft.Json;

namespace CarStore.ApiClient
{
    public class CarStoreApiClient
    {
        private HttpClient httpClient;

        public CarStoreApiClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
            this.httpClient.BaseAddress = new Uri("http://localhost:5000/");

            this.httpClient.DefaultRequestHeaders.Accept.Clear();
            this.httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<StoreModel>> GetAllStores()
        {
            var response = await this.httpClient.GetAsync($"api/Stores");
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            var stores = new Newtonsoft.Json.JsonSerializer().Deserialize<IEnumerable<StoreModel>>(jsonReader);

            return stores;
        }

        public async Task<StoreModel> GetStore(int id)
        {
            var response = await this.httpClient.GetAsync($"api/Store/{id}");
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(stream);
            using var jsonReader = new JsonTextReader(streamReader);
            var store = new Newtonsoft.Json.JsonSerializer().Deserialize<StoreModel>(jsonReader);

            return store;
        }

        public async Task<StoreModel> CreateStore(CreateStoreModel model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this.httpClient.PostAsync("api/Store", content);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<StoreModel>(result);
        }

        public async Task<StoreModel> PutStore(CreateStoreModel model)
        {
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = await this.httpClient.PutAsync("api/Store", content);

            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<StoreModel>(result);
        }

        public async Task<string> LongRunning()
        {
            var cancellationTokenSource = new CancellationTokenSource();
            cancellationTokenSource.CancelAfter(TimeSpan.FromSeconds(5));
            var response = await this.httpClient.GetAsync($"api/Stores/long-running", cancellationTokenSource.Token);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}