using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(ApiDbContext context, ISimpleLogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User> FindByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.Users.Update(user);
        }

        public void Remove(User user)
        {
            _context.Users.Remove(user);
        }
    }
}
