using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Extensions;
using CarStore.API.Helpers;
using CarStore.API.Resource;
using CarStore.Domain.Models;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CarStore.API.Controllers
{
    [Route("api/store/{storeId}/cars")]
    [Authorize]
    public class CarController : BaseController
    {
        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public CarController(ICarService carService, IMapper mapper, INotificationService notificationService)
        {
            _carService = carService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IEnumerable<CarResource>> GetAllAsync(int storeId, CancellationToken token)
        {
            var cars = await _carService.ListAsync(storeId, token);
            var resources = _mapper.Map<IEnumerable<Car>, IEnumerable<CarResource>>(cars);

            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int storeId, int id)
        {
            if (storeId < 0 || id < 0)
            {
                throw new ArgumentException("Negative parameter exception");
            }

            var car = await _carService.GetAsync(storeId, id);
            if (car == null)
            {
                return NotFound();
            }

            // Add Header
            var eTag = HashFactory.GetHash(car.LastModified.ToString());
            HttpContext.Response.Headers.Add(EtagHeader, eTag);

            var resource = _mapper.Map<Car, CarResource>(car);

            return Ok(resource);
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync(int storeId, [FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var carModel = _mapper.Map<SaveCarResource, Car>(resource);

            var result = await _carService.SaveAsync(storeId, carModel);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            this._notificationService.Notify("Car created!");

            var carResource = _mapper.Map<Car, CarResource>(result.Car);

            return Ok(carResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int storeId, int id, [FromBody] SaveCarResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            // ETag is required
            if (!HttpContext.Request.Headers.ContainsKey(MatchHeader))
            {
                return new StatusCodeResult(412);
            }
            var ETag = HttpContext.Request.Headers[MatchHeader];

            var carModel = _mapper.Map<SaveCarResource, Car>(resource);

            var result = await _carService.UpdateAsync(storeId, id, carModel, ETag);

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