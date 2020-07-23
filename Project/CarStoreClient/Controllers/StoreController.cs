using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CarStore.API.Resource;
using CarStore.ApiClient;
using CarStore.ApiClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Client.Controllers
{
    public class StoreController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            var httpClient = new HttpClient();

            var carStoreApiClient = new CarStoreApiClient(httpClient);

            var storeResponse = await carStoreApiClient.GetAllStores();

            return View(storeResponse);
        }
    }
}