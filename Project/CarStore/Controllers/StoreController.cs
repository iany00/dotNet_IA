using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarStore.API.Resource;
using CarStore.Domain.Models;
using CarStore.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        private readonly IMapper _mapper;

        public StoreController(IStoreService storeService, IMapper mapper)
        {
            _storeService = storeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<StoreResource>> GetAllAsync()
        {
            var stores = await _storeService.ListAsync();
            var resource = _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResource>>(stores);

            return resource;
        }

        /*[HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveStoreResource resource)
        {

        }*/
    }
}