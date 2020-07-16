using System;
using System.Collections.Generic;
using System.Text;
using CarStore.Domain.Models;

namespace CarStore.Domain.Services.Communication
{
    public class StoreResponse : BaseResponse
    {
        public Store Store { get; private set; }
        public StoreResponse(bool success, string message, Store store) : base(success, message)
        {
            Store = store;
        }

        public StoreResponse(Store store) : this(true, string.Empty, store)
        { }

        public StoreResponse(string message) : this(false, message, null)
        { }
    }
}
