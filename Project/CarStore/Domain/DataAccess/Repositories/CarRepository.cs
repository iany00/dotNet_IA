using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class CarRepository : BaseRepository, ICarRepository
    {
        public CarRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Car>> ListAsyncTask()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
        }
    }
}
