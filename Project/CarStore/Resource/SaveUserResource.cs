using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Enums;

namespace CarStore.API.Resource
{
    public class SaveUserResource
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ERole Role { get; set; }
    }
}
