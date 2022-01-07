using REST_API_Calculadora_ASP.NET.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        T Create(T entity);
        T FindById(long id);
        List<T> FindAll();
        T Update(T entity);
        void Delete(long id);
        List<T> FindWithPagedSearch(string query);
        int GetCount(string query);
    }
}
