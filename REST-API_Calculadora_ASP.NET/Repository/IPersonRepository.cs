using REST_API_Calculadora_ASP.NET.Models;
using REST_API_Calculadora_ASP.NET.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        Person Disable(long id);
        List<Person> FindByName(string firstName, string lastName);
    }
}
