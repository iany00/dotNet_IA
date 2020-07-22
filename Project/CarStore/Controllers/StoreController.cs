using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
    public class StoreController : BaseController
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public StoreController(IStoreService storeService, IMapper mapper, INotificationService notificationService)
        {
            _storeService = storeService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet]
        [Route("/api/Stores")]
        public async Task<IEnumerable<StoreResource>> GetAllAsync()
        {
            var stores = await _storeService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);

            return resource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("Negative parameter exception");
            }

            var store = await _storeService.GetAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            // Add Header
            var eTag = HashFactory.GetHash(store.LastModified.ToString());
            HttpContext.Response.Headers.Add(EtagHeader, eTag);

            var resource = _mapper.Map<Store, StoreResource>(store);

            return Ok(resource);
        }

       
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var store = _mapper.Map<SaveStoreResource, Store>(resource);

            var result = await _storeService.SaveAsync(store);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var storeResource = _mapper.Map<Store, StoreResource>(result.Store);

            return Ok(storeResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveStoreResource resource)
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

            var store = _mapper.Map<SaveStoreResource, Store>(resource);

            var result = await _storeService.UpdateAsync(id, store, ETag);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var storeResource = _mapper.Map<Store, StoreResource>(result.Store);

            return Ok(storeResource);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _storeService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var resourece = _mapper.Map<Store, StoreResource>(result.Store);
            return Ok(resourece);
        }
    }
}