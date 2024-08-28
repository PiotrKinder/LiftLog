using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Auth;

namespace API.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration, IMediator mediator)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            try
            {
                var token = await Mediator.Send(new Login.Query
                {
                    email = loginRequest.Email,
                    password = loginRequest.Password,
                    key = _configuration["Jwt:Key"],
                    audience = _configuration["Jwt:Issuer"],
                    issuer = _configuration["Jwt:Issuer"]
                });
                return Ok(new { token });
            } catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
