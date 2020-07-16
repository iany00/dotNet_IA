using System;
using System.Collections.Generic;
using System.Text;
using CarStore.Domain.Models;

namespace CarStore.Domain.Services.Communication
{
    public class CarManufacturerResponse : BaseResponse
    {
        public CarManufacturer CarManufacturer { get; private set; }

        public CarManufacturerResponse(bool success, string message, CarManufacturer carManufacturer) : base(success, message)
        {
            CarManufacturer = carManufacturer;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="carManufacturer">Saved Car manufacturer.</param>
        /// <returns>Response.</returns>
        public CarManufacturerResponse(CarManufacturer carManufacturer) : this(true, string.Empty, carManufacturer)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public CarManufacturerResponse(string message) : this(false, message, null)
        { }
    }
}
