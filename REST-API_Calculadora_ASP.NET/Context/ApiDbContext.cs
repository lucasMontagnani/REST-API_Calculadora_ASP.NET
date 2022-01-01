using Microsoft.EntityFrameworkCore;
using REST_API_Calculadora_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Context
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext() 
        {
        }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {
        }

        public DbSet<Person> Person_s { get; set; }

    }
}
