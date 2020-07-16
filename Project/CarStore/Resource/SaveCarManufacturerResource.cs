using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarStore.API.Resource
{
    public class SaveCarManufacturerResource
    {
        [Required]
        public string Name { get; set; }
    }
}
