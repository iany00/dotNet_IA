using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface ICarManufacturerService
    {
        Task<CarManufacturer> GetAsync(int id);
        Task<IEnumerable<CarManufacturer>> ListAsync();

        Task<CarManufacturerResponse> SaveAsync(CarManufacturer manufacturer);

        Task<CarManufacturerResponse> UpdateAsync(int id, CarManufacturer manufacturer, string ETag);
        Task<CarManufacturerResponse> DeleteAsync(int id);
    }
}
