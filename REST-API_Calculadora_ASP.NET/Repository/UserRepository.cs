using REST_API_Calculadora_ASP.NET.Context;
using REST_API_Calculadora_ASP.NET.Data.VO;
using REST_API_Calculadora_ASP.NET.Models;
using REST_API_Calculadora_ASP.NET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _context;
        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }
        public User ValidationCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        public User RefreshUserInfo(User user)
        {
            if(!_context.Users.Any(u => u.Id.Equals(user.Id)))
            {
                return null;
            }
            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                    return user;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return result;
        }

        public User ValidationCredentials(string username)
        {
            return _context.Users.SingleOrDefault(u => (u.UserName == username));
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Users.SingleOrDefault(u => (u.UserName == userName));
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);
            return BitConverter.ToString(hashedBytes);
        }

        private bool Exists(long id)
        {
            return _context.Users.Any(p => p.Id.Equals(id));
        }
    }
}
