using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Hypermedia.Abstract
{
    public interface IResponseEnricher
    {
        bool CanEnrich (ResultExecutingContext context);
        Task Enrich (ResultExecutingContext context);
    }
}
