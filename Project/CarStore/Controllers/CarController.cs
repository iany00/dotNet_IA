using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.Domain.Services;
using CarStore.Domain.Models;
using CarStore.Extensions;
using CarStore.Resource;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.Controllers
{
    [Route("api/[controller]")]
    public class CarController : Controller
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CarResource>> GetAllAsync()
        {
            var cars = await _carService.ListAsyncTask();
            var resources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);

            return resources;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var category = _mapper.Map<SaveCarResource, Car>(resource);

            var result = await _carService.SaveAsync(category);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carResource = _mapper.Map<Car, CarResource>(result.Car);

            return Ok(carResource);
        }

    }
}