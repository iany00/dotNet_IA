using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.Services;
using Microsoft.Extensions.Logging;

namespace CarStore.API.Services
{
    public class NotificationService : INotificationService
    {
        private readonly Guid id;
        private readonly ILogger<NotificationService> logger;

        public NotificationService(ILoggerFactory factory)
        {
            this.logger = factory.CreateLogger<NotificationService>();

            this.id = Guid.NewGuid();
        }

        public void Notify(string message)
        {
            this.logger.LogInformation($"{this.id} : {message}");
        }
    }
}
