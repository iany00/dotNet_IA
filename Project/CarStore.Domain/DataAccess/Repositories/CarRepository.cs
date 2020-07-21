using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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

        public async Task<IEnumerable<Car>> ListAsync(int storeId, CancellationToken token)
        {
            return await _context.Cars
                .Include(c => c.Store)
                .Where(c => c.Store.Id == storeId)
                .ToListAsync(token);
        }

        public async Task AddAsync(Car car)
        {
            await _context.Cars.AddAsync(car);
        }

        public async Task<Car> FindByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public void Update(Car car)
        {
            _context.Entry(car).State = EntityState.Modified;

            _context.Cars.Update(car);
        }

        public void Remove(Car car)
        {
            _context.Cars.Remove(car);
        }

        public async Task<Car> FindStoreCarAsync(int storeId, int id)
        {
            return await _context.Cars
                .Include(c => c.Store)
                .Where(c => c.Store.Id == storeId)
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Car>> GetCarList(int storeId)
        {
            return await _context.Cars
                .Include(c => c.Store)
                .Where(c => c.Store.Id == storeId)
                .ToListAsync();
        }
    }
}
