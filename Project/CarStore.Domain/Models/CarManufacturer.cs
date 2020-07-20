using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Domain.Models
{
    public class CarManufacturer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}