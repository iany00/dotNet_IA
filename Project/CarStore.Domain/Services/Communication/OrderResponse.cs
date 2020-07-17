using System;
using System.Collections.Generic;
using System.Text;
using CarStore.Domain.Models;

namespace CarStore.Domain.Services.Communication
{
    public class OrderResponse : BaseResponse
    {
        public Order Order { get; private set; }
        public OrderResponse(bool success, string message, Order order) : base(success, message)
        {
            Order = order;
        }

        public OrderResponse(Order order) : this(true, string.Empty, order)
        { }

        public OrderResponse(string message) : this(false, message, null)
        { }
    }
}
