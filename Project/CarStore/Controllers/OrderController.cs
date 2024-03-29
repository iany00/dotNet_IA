﻿using System;
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
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStore.API.Controllers
{
    [Route("api/store/{storeId}/orders")]
    [ApiController]
    [Authorize]
    public class OrderController : BaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        private readonly INotificationService _notificationService;

        public OrderController(IOrderService orderService, IMapper mapper, INotificationService notificationService)
        {
            _orderService = orderService;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IEnumerable<OrderResource>> GetAllAsync(int storeId, CancellationToken token)
        {
            var resource = await _orderService.ListAsync(storeId, token);

            var orderResource = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(resource);

            return orderResource;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int storeId, int id)
        {
            if (storeId < 0 || id < 0)
            {
                throw new ArgumentException("Negative parameter exception");
            }

            var order = await _orderService.GetAsync(storeId, id);
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
        public async Task<IActionResult> PostAsync(int storeId, [FromBody] SaveOrderResource resource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.GetErrorMessages());
            }

            var order = _mapper.Map<SaveOrderResource, Order>(resource);

            var result = await _orderService.SaveAsync(storeId, order);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            var orderResource = _mapper.Map<Order, OrderResource>(result.Order);

            return Ok(orderResource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int storeId, int id, [FromBody] SaveOrderResource resource)
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

            var result = await _orderService.UpdateAsync(storeId, id, order, ETag);

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