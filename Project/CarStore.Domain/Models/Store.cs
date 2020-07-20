using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Domain.Models
{
    public class Store
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        public IList<User> Users { get; set; }

        public IList<Car> Cars { get; set; }

        public IList<Order> Orders { get; set; }

        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
