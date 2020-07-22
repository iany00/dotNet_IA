using System;
using System.ComponentModel.DataAnnotations;

namespace CarStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CarId { get; set; }

        public int StoreId { get; set; }

        public Store Store { get; set; }

        public string Invoice { get; set; }
        public DateTime LastModified { get; set; }
        [Timestamp] 
        public byte[] RowVersion { get; set; }
    }
}
