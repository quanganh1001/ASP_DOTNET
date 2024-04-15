using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using BCrypt.Net;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email) ??
            throw new Exception($"User with email {email} not found."); ;
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.FindAsync(id) ??
            throw new Exception($"User with id {id} not found.");
        }

        public async Task<User> GetByUserName(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username) ??
            throw new Exception($"User with username {username} not found."); ;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> PostUser(User user)
        {

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.HasedPassword);

            // Gán mật khẩu đã được mã hóa cho người dùng
            user.HasedPassword = hashedPassword;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                throw new Exception("Id does not match");
            }

            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Users.Any(e => e.Id == id))
                {
                    throw new Exception("NotFound");
                }
                else
                {
                    throw;
                }
            }

            return user;
        }

        public async void DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id) ?? throw new Exception("NotFound");
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}