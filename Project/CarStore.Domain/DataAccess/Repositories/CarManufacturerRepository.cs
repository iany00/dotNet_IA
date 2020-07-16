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
    public class CarManufacturerRepository : BaseRepository, ICarManufacturerRepository
    {
        public CarManufacturerRepository(ApiDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<CarManufacturer>> ListAsync()
        {
            return await _context.CarManufacturers.ToListAsync();
        }

        public async Task AddAsync(CarManufacturer manufacturer)
        {
            await _context.AddAsync(manufacturer);
        }

        public async Task<CarManufacturer> FindByIdAsync(int id)
        {
            return await _context.CarManufacturers.FindAsync(id);
        }

        public void Update(CarManufacturer manufacturer)
        {
            _context.CarManufacturers.Update(manufacturer);
        }

        public void Remove(CarManufacturer manufacturer)
        {
            _context.CarManufacturers.Remove(manufacturer);
        }
    }
}
