using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using REST_API_Calculadora_ASP.NET.Data.VO;
using REST_API_Calculadora_ASP.NET.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REST_API_Calculadora_ASP.NET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILoginService _loginService;
        public AuthenticationController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [Route("signin")]
        public IActionResult Signin([FromBody] UserVO user)
        {
            if (user == null)
            {
                return BadRequest("Ivalid client request");
            }
            var token = _loginService.ValidateCredentials(user);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost]
        [Route("refresh")]
        public IActionResult Refresh([FromBody] TokenVO tokenVo)
        {
            if (tokenVo is null)
            {
                return BadRequest("Ivalid client request");
            }
            var token = _loginService.ValidateCredentials(tokenVo);
            if (token == null)
            {
                return BadRequest("Ivalid client request");
            }
            return Ok(token);
        }


        [HttpGet]
        [Route("revoke")]
        [Authorize("Bearer")]
        public IActionResult Revoke()
        {
            var username = User.Identity.Name;
            var result = _loginService.RevokeToken(username);

            if (!result) return BadRequest("Ivalid client request");
            return NoContent();
        }
    }
}
