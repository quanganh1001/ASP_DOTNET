using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IUserService
    {
        Task<User> GetById(int id);
        Task<User> GetByUserName(string username);
        Task<User> GetByEmail(string email);
        Task<IEnumerable<User>> GetUsers();
        Task<User> PostUser(User user);
        Task<User> PutUser(int id, User user);
        void DeleteUser(int id);
    }
}