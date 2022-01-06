using REST_API_Calculadora_ASP.NET.Data.VO;
using REST_API_Calculadora_ASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Repository.Generic
{
    public interface IUserRepository
    {
        User ValidationCredentials(UserVO user);
        User RefreshUserInfo(User user);
        bool RevokeToken(string usarname);
        User ValidationCredentials(string username);
    }
}
