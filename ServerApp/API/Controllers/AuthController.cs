using Application.Auth;
using DTO.Contracts.Auth;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login([FromBody] AuthRequest loginRequest)
        {
            try
            {
                var token = await Mediator.Send(new Login.Query
                {
                    AuthRequest = loginRequest,
                    TokenKeys = new DTO.DTO.JwtData()
                    {
                        key = _configuration["Jwt:Key"],
                        audience = _configuration["Jwt:Audience"],
                        issuer = _configuration["Jwt:Issuer"]
                    }

                });
                return Ok(new { token });
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
