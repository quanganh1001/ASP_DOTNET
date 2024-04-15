using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetById(int id);
        Task<User> GetByUserName(string username);
        Task<User> GetByEmail(string email);
        Task<User> PutUser(int id, User user);
        Task<User> PostUser(User user);
        Task<IEnumerable<User>> GetUsers();
        void DeleteUser(int id);
    }
}