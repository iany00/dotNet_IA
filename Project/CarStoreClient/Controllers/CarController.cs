using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.API.Resource;
using CarStore.ApiClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Client.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<CarModel>());
        }
    }
}