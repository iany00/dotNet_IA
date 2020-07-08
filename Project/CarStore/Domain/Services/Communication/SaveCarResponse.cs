using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CarStore.Domain.Models;

namespace CarStore.Domain.Services.Communication
{
    public class SaveCarResponse : BaseResponse
    {
        public Car Car { get; private set; }
        public SaveCarResponse(bool success, string message, Car car) : base(success, message)
        {
            Car = car;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="Car">Saved Car.</param>
        /// <returns>Response.</returns>
        public SaveCarResponse(Car car) : this(true, string.Empty, car)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public SaveCarResponse(string message) : this(false, message, null)
        { }
    }
}
