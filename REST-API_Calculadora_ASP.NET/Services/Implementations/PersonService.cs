using REST_API_Calculadora_ASP.NET.Context;
using REST_API_Calculadora_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Services.Implementations
{
    public class PersonService : IPersonService
    {
        private ApiDbContext _context;
        public PersonService(ApiDbContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Person_s.ToList();
        }

        public Person FindById(long id)
        {
            return _context.Person_s.SingleOrDefault(p => p.Id.Equals(id));
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return person;
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id))
            {
                return new Person();
            }
            var result = _context.Person_s.SingleOrDefault(p => p.Id.Equals(person.Id));
            if(result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }           
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Person_s.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Person_s.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private bool Exists(long id)
        {
            return _context.Person_s.Any(p => p.Id.Equals(id));
        }
    }
}
