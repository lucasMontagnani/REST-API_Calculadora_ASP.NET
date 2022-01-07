using REST_API_Calculadora_ASP.NET.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Models
{
    [Table("person")] // Mapeamento para um banco já existendo (no migrations)
    public class Person : BaseEntity
    {
        [Column("first_name")] // Mapaear para a tabela do banco criado a parte, onde está coluna se encontra escrita de maneira diferente
        public string FirstName { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("address")]
        public string Address { get; set; }
        [Column("gender")]
        public string Gender { get; set; }
        [Column("enabled")]
        public bool Enabled { get; set; }
    }
}
