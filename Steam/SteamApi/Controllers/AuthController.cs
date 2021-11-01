using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Steam.Domain.Commands.Outputs;
using Steam.Domain.Entidades;
using SteamApi.Token;
using System;

namespace SteamApi.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenGenerator _tokenGenerator;

        public AuthController(IConfiguration configuration, ITokenGenerator tokenGenerator)
        {
            _configuration = configuration;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost]
        [Route("api/auth/login")]
        public IActionResult Login([FromBody] InserirLoginCommand command)
        {
            try
            {
                var tokenLogin = _configuration["Jwt:Login"];
                var tokenPassword = _configuration["Jwt:Password"];

                if (command.Login == tokenLogin && command.Password == tokenPassword)
                {
                    return Ok(new LoginCommandResult(true, "Usuário autenticado com sucesso!", new
                    {
                        Token = _tokenGenerator.GenerateToken(),
                        TokenExpires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"]))
                    }));
                }
                else
                    return StatusCode(401);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
