using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.API.Resource
{
    public class OrderResource
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CarId { get; set; }

        public int StoreId { get; set; }
        public string Invoice { get; set; }
    }
}
