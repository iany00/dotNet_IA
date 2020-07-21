using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Domain.Services
{
    public interface ISimpleLogger
    {
        void LogInfo(string message);
    }
}
