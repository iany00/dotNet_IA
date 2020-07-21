using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Services;
using Microsoft.Extensions.Logging;

namespace CarStore.API.Services
{
    public class SimpleLogger : ISimpleLogger
    {
        private readonly Guid id;
        private readonly ILogger<SimpleLogger> logger;

        public SimpleLogger(ILogger<SimpleLogger> logger)
        {
            this.id = Guid.NewGuid();

            this.logger = logger;
        }

        public void LogInfo(string message)
        {
            this.logger.LogInformation($"{this.id} : {message}");
        }
    }
}
