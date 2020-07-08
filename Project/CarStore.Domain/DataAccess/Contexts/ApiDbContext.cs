using CarStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Domain.DataAccess.Contexts
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Store> Stores { get; set; }
        public DbSet<CarPhotos> CarPhotos { get; set; }

        // TODO: do we need to set foreingkeys?
    }

   
}
