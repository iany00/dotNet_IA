using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class CarRepository : BaseRepository, ICarRepository
    {
        public IMemoryCache _memoryCache;

        public CarRepository(ApiDbContext context,ISimpleLogger logger, IMemoryCache memoryCache) : base(context, logger)
        {
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Car>> ListAsync(int storeId, CancellationToken token)
        {
            var key = $"_cars_for_store_{storeId}";

            // In Memory cache
            var list = await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                var cacheTokenSource = this._memoryCache.GetOrCreate($"_CTS{storeId}", cacheEntry => new CancellationTokenSource());
                
                entry.AddExpirationToken(new CancellationChangeToken(cacheTokenSource.Token));
                entry.RegisterPostEvictionCallback(this.Callback, this);

                this._logger.LogInfo("Cars-Get(storeId) db hit");

                return  _context.Cars
                    .Include(c => c.Store)
                    .Where(c => c.Store.Id == storeId)
                    .ToListAsync(token);
            });

            return list;
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
