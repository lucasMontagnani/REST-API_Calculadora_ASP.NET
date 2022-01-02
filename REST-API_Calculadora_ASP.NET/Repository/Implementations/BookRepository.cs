using REST_API_Calculadora_ASP.NET.Context;
using REST_API_Calculadora_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ApiDbContext _context;
        public BookRepository(ApiDbContext context)
        {
            _context = context;
        }
        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }

        public Book FindById(long id)
        {
            return _context.Books.SingleOrDefault(b => b.Id.Equals(id));
        }

        public Book Create(Book book)
        {
            try
            {
                _context.Books.Add(book); // N esquece isso aqui
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return book;
        }

        public Book Update(Book book)
        {
            if (!Exists(book.Id))
            {
                return null;
            }
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(book.Id));
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(book);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return book;
        }

        public void Delete(long id)
        {
            var result = _context.Books.SingleOrDefault(b => b.Id.Equals(id));
            if (result != null)
            {
                try
                {
                    _context.Books.Remove(result);
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
            return _context.Books.Any(b => b.Id.Equals(id));
        }
    }
}
