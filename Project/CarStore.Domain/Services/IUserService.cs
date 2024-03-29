﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CarStore.Domain.Models;
using CarStore.Domain.Services.Communication;

namespace CarStore.Domain.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> SaveAsync(User user);

        Task<UserResponse> UpdateAsync(int id, User user, string ETag);
        Task<UserResponse> DeleteAsync(int id);
        Task<User> GetAsync(int id);
        Task<UserResponse> Register(User user, string password);
    }
}
