using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Auth
{
    public class Login
    {
        public class Query : IRequest<string>
        {
            public string email {  get; set; }
            public string password { get; set; }
            public string key { get; set; }
            public string issuer { get; set; }
            public string audience { get; set; }

        }

        public class Handler : IRequestHandler<Query,string>
        {
            private readonly DataContext _context;

            private class JwtData()
            {
                public string key { set; get; }
                public string issuer { set; get; }
                public string audience { set; get; }
            }
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<string> Handle(Query request, CancellationToken cancellationToken) {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.email);
                if (user == null && !VerifyPassword(request.password, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid email or password.");
                }
                JwtData jwtData = new JwtData() { key = request.key, audience=request.audience, issuer=request.issuer};    
                return GenerateJwtToken(request.email, jwtData);
            }
            private bool VerifyPassword(string password, string storedHash)
            {
                var passwordHasher = new PasswordHasher<User>();
                var verificationResult = passwordHasher.VerifyHashedPassword(null, storedHash, password);

                return verificationResult == PasswordVerificationResult.Success;
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
