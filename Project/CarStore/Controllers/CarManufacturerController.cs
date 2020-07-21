using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Extensions;
using CarStore.API.Helpers;
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
    public class CarManufacturerController : BaseController
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var manufacturer = await _carManufacturerService.GetAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            // Add Header
            var eTag = HashFactory.GetHash(manufacturer.LastModified.ToString());
            HttpContext.Response.Headers.Add(EtagHeader, eTag);

            var resource = _mapper.Map<CarManufacturer, CarManufacturerResource>(manufacturer);
            
            return Ok(resource);
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

            // ETag is required
            if (!HttpContext.Request.Headers.ContainsKey(MatchHeader))
            {
                return new StatusCodeResult(412);
            }
            var ETag = HttpContext.Request.Headers[MatchHeader];

            var manufacturer = _mapper.Map<SaveCarManufacturerResource, CarManufacturer>(resource);

            var result = await _carManufacturerService.UpdateAsync(id, manufacturer, ETag);

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