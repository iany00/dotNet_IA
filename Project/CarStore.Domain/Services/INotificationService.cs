using System;
using Microsoft.Extensions.Logging;

namespace CarStore.Domain.Services
{

    public interface INotificationService
    {
        void Notify(string message);
    }
}
