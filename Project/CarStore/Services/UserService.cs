using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarStore.API.Helpers;
using CarStore.Domain.Models;
using CarStore.Domain.Repositories;
using CarStore.Domain.Services;
using CarStore.Domain.Services.Communication;

namespace CarStore.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
               return new UserResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user, string ETag)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
            {
                return new UserResponse("User not found!");
            }

            if (HashFactory.GetHash(existingUser.LastModified.ToString()) != ETag)
            {
                return new UserResponse("Invalid If-match!");
            }

            existingUser.Name = user.Name;
            existingUser.Role = user.Role;
            existingUser.LastModified = DateTime.Now;

            try
            {
                _userRepository.Update(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when saving the user: {e.Message}");
            }
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);

            if (existingUser == null)
            {
                return new UserResponse("User not found!");
            }

            try
            {
                _userRepository.Remove(existingUser);
                await _unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred when deleting the user: {e.Message}");
            }
        }

        public async Task<User> GetAsync(int id)
        {
            return await _userRepository.FindByIdAsync(id);
        }
    }
}
