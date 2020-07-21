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
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResource>> GetAllAsync()
        {
            var resource = await _orderService.ListAsync();

            var orderResource = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(resource);

            return orderResource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var order = await _orderService.GetAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            // Add Header
            var eTag = HashFactory.GetHash(order.LastModified.ToString());
            HttpContext.Response.Headers.Add(EtagHeader, eTag);

            var resource = _mapper.Map<Order, OrderResource>(order);

            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var order = _mapper.Map<SaveOrderResource, Order>(resource);

            var result = await _orderService.SaveAsync(order);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var orderResource = _mapper.Map<Order, OrderResource>(result.Order);

            return Ok(orderResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveOrderResource resource)
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

            var order = _mapper.Map<SaveOrderResource, Order>(resource);

            var result = await _orderService.UpdateAsync(id, order, ETag);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var orderResource = _mapper.Map<Order, OrderResource>(result.Order);

            return Ok(orderResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _orderService.DeleteAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result.Order);
        }
    }
}