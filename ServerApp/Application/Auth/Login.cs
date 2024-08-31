using Application.Helpers;
using DTO.Contracts.Auth;
using DTO.DTO;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Auth
{
    public class Login
    {
        public class Query : IRequest<string>
        {
            public AuthRequest AuthRequest { get; set; }
            public JwtData TokenKeys { get; set; }

        }

        public class Handler : IRequestHandler<Query, string>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(Query request, CancellationToken cancellationToken)
            {
                var userData = request.AuthRequest;
                var tokenData = request.TokenKeys;
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == userData.email);
                if (user == null || !PasswordVerification.Check(userData.password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }
                return GenerateJwtToken(userData.email, tokenData);
            }
            private string GenerateJwtToken(string username, JwtData jwtData)
            {
                var claims = new[]
                {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtData.key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: jwtData.issuer,
                    audience: jwtData.audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }
}
