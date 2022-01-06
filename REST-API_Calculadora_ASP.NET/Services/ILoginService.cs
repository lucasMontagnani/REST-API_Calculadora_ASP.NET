using REST_API_Calculadora_ASP.NET.Data.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Services
{
    public interface ILoginService
    {
        TokenVO ValidateCredentials(UserVO user);
        TokenVO ValidateCredentials(TokenVO token);
        bool RevokeToken(string usarname);
    }
}
