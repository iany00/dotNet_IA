using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public StoreRepository(ApiDbContext context, ISimpleLogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Store>> ListAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public async Task AddAsync(Store store)
        {
            await _context.Stores.AddAsync(store);
        }

        public async Task<Store> FindByIdAsync(int id)
        {
            return await _context.Stores.FindAsync(id);
        }

        public void Update(Store store)
        {
            _context.Entry(store).State = EntityState.Modified;
            _context.Stores.Update(store);
        }

        public void Remove(Store store)
        {
            _context.Stores.Remove(store);
        }
    }
}
