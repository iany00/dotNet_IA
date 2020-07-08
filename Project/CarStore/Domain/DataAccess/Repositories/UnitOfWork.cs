using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Repositories;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiDbContext _context;

        public UnitOfWork(ApiDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
