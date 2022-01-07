using REST_API_Calculadora_ASP.NET.Context;
using REST_API_Calculadora_ASP.NET.Models;
using REST_API_Calculadora_ASP.NET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository.Implementations
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(ApiDbContext context) : base(context) { }
        public Person Disable(long id)
        {
            if(!_context.Person_s.Any(p => p.Id.Equals(id))) return null;
            var user = _context.Person_s.SingleOrDefault(p => p.Id.Equals(id));
            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return user;
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Person_s.Where(
                    p => p.FirstName.Contains(firstName)
                    && p.LastName.Contains(lastName)).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Person_s.Where(
                    p => p.LastName.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Person_s.Where(
                    p => p.FirstName.Contains(firstName)).ToList();
            }
            return null;
        }
    }
}
