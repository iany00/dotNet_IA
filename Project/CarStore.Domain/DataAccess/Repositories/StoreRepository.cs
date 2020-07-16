using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public StoreRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Store>> ListAsync()
        {
            return await _context.Stores.ToListAsync();
        }

        public Task AddAsync(Store store)
        {
            throw new NotImplementedException();
        }

        public Task<Store> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Store store)
        {
            throw new NotImplementedException();
        }

        public void Remove(Store store)
        {
            throw new NotImplementedException();
        }
    }
}
