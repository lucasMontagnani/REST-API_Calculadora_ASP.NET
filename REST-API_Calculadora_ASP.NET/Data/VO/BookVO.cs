using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Data.VO
{
    public class BookVO
    {
        //[JsonPropertyName("Identifier")] // Serialização: Serve como um Label para os campos dos atributos quando no Endpoint
        public long Id { get; set; }
        //[JsonPropertyName("Author's Name")]
        public string Author { get; set; }
        //[JsonPropertyName("Realise Date")]
        public DateTime LaunchDate { get; set; }
        //[JsonPropertyName("Cost")]
        public decimal Price { get; set; }
        //[JsonPropertyName("Book's Tittle")]
        public string Title { get; set; }
    }
}
