using System;
using System.Net.Http;
using System.Threading.Tasks;
using CarStore.ApiClient.Models;

namespace CarStore.ApiClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // single instance  
            var httpClient = new HttpClient();

            var carStoreApiClient = new CarStoreApiClient(httpClient);

            var storeResponse = await carStoreApiClient.GetStore(1);

            var store = await carStoreApiClient.CreateStore(new CreateStoreModel{Name = "AudiStore",Address = "Bucuresti"});
            Console.WriteLine("Create store with id: " + store.Id);

            await carStoreApiClient.LongRunning();
        }
    }
}
