using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Extensions;
using CarStore.API.Resource;
using CarStore.Domain.Models;
using CarStore.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CarManufacturerController : ControllerBase
    {
        private readonly ICarManufacturerService _carManufacturerService;
        private readonly IMapper _mapper;

        public CarManufacturerController(ICarManufacturerService manufactureService, IMapper mapper)
        {
            _carManufacturerService = manufactureService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CarManufacturerResource>> GetAllAsync()
        {
            var manufacturers = await _carManufacturerService.ListAsync();
            var resource = _mapper.Map<IEnumerable<CarManufacturer>, IEnumerable<CarManufacturerResource>>(manufacturers);
            
            return resource;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCarManufacturerResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var manufacturer = _mapper.Map<SaveCarManufacturerResource, CarManufacturer>(resource);

            var result = await _carManufacturerService.SaveAsync(manufacturer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carManufacturerResource = _mapper.Map<CarManufacturer, CarManufacturerResource>(result.CarManufacturer);
            return Ok(carManufacturerResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCarManufacturerResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var manufacturer = _mapper.Map<SaveCarManufacturerResource, CarManufacturer>(resource);

            var result = await _carManufacturerService.UpdateAsync(id, manufacturer);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var carManufacturerResource = _mapper.Map<CarManufacturer, CarManufacturerResource>(result.CarManufacturer);

            return Ok(carManufacturerResource);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _carManufacturerService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var manufacturerResource = _mapper.Map<CarManufacturer, CarManufacturerResource>(result.CarManufacturer);
            return Ok(manufacturerResource);
        }
    }
}