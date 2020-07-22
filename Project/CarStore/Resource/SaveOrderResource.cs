using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.API.Resource
{
    public class SaveOrderResource
    {
        public int UserId { get; set; }

        public int CarId { get; set; }

        public int StoreId { get; set; }

        public int Invoice { get; set; }
    }
}
