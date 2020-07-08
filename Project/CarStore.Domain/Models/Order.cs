namespace CarStore.Domain.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int CarId { get; set; }

        public int StoreId { get; set; }
    }
}
