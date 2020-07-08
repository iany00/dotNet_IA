using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CarStore.Domain.Enums;

namespace CarStore.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public ERole Role { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}
