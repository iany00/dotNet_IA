﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Extensions;
using CarStore.API.Resource;
using CarStore.Domain.Models;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
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
            var cars = await _carService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var car = await _carService.GetAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            var resource = _mapper.Map<Car, CarResource>(car);

            return Ok(resource);

        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var carModel = _mapper.Map<SaveCarResource, Car>(resource);

            var result = await _carService.SaveAsync(carModel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carResource = _mapper.Map<Car, CarResource>(result.Car);

            return Ok(carResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var carModel = _mapper.Map<SaveCarResource, Car>(resource);

            var result = await _carService.UpdateAsync(id, carModel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carResource = _mapper.Map<Car, CarResource>(result.Car);

            return Ok(carResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _carService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Car, CarResource>(result.Car);
            return Ok(categoryResource);
        }

    }
}