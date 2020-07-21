using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.Domain.DataAccess.Contexts;
using CarStore.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace CarStore.Domain.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected readonly ApiDbContext _context;
        public readonly ISimpleLogger _logger;

        public BaseRepository(ApiDbContext context, ISimpleLogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Callback(object key, object value, EvictionReason reason, object state)
        {
            _logger.LogInfo($"cache reset: {reason} on key: {key}");
        }
    }
}
