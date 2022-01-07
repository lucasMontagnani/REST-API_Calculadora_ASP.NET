using Microsoft.EntityFrameworkCore;
using REST_API_Calculadora_ASP.NET.Context;
using REST_API_Calculadora_ASP.NET.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository.Generic
{
    //Controller roteia a requisição do client, e indica o método através da rota,
    //o método invoca o Service(que cuida das regras de negíócio),
    //e este chama o Repository(que cuida do acesso ao banco de dados por meio do Context)
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        protected readonly ApiDbContext _context;
        private DbSet<T> dataset;
        public GenericRepository(ApiDbContext context)
        {
            _context = context;
            dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return dataset.ToList();
        }

        public T FindById(long id)
        {
            return dataset.SingleOrDefault(p => p.Id.Equals(id));
        }

        public T Create(T entity)
        {
            try
            {
                dataset.Add(entity);
                _context.SaveChanges();
                return entity;
            }
            catch (Exception)
            {
                throw;
            }  
        }

        public T Update(T entity)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(entity.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(entity);
                    _context.SaveChanges();
                    return entity;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                return null;
            }
            
        }

        public void Delete(long id)
        {
            var result = dataset.SingleOrDefault(p => p.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    dataset.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<T> FindWithPagedSearch(string query)
        {
            return dataset.FromSqlRaw<T>(query).ToList();
        }

        public int GetCount(string query)
        {
            var result = "";
            using (var connection = _context.Database.GetDbConnection())
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    result = command.ExecuteScalar().ToString();
                }
            }
            return int.Parse(result);
        }
    }
}
