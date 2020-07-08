using System;
using Microsoft.Extensions.Logging;

namespace CarStore.Domain.Services
{

    public interface INotificationService
    {
        void Notify(string message);
    }

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
