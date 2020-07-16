using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;

namespace CarStore.Domain.Repositories
{
    public interface ICarManufacturerRepository
    {
        Task<IEnumerable<CarManufacturer>> ListAsync();
        Task AddAsync(CarManufacturer manufacturer);
        Task<CarManufacturer> FindByIdAsync(int id);

        void Update(CarManufacturer manufacturer);

        void Remove(CarManufacturer manufacturer);
    }
}
