using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services
{
    public class UserService(IUserRepository userReopository) : IUserService
    {
        private readonly IUserRepository _userRepository = userReopository;

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _userRepository.GetByEmail(email);
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _userRepository.GetByUserName(username);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<User> PostUser(User user)
        {
           return await _userRepository.PostUser(user);
        }

        public async Task<User> PutUser(int id, User user)
        {
            return await _userRepository.PutUser(id,user);
        }
    }
}