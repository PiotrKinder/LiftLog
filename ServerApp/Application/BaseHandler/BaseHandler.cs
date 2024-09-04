using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System.Security.Claims;

namespace Application.Base
{
    public abstract class BaseHandler
    {
        protected readonly DataContext _context;
        protected readonly IHttpContextAccessor _httpContext;

        protected BaseHandler(DataContext context)
        {
            _context = context;
        }

        protected BaseHandler(DataContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }


        protected async Task<Guid> GetUserId()
        {
            var id = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (id == null)
            {
                throw new Exception("Invalid token.");
            }

            return Guid.Parse(id);
        }

        public static bool ChackPassword(string password, string storedHash)
        {
            var passwordHasher = new PasswordHasher<User>();
            var verificationResult = passwordHasher.VerifyHashedPassword(null, storedHash, password);

            return verificationResult == PasswordVerificationResult.Success;
        }
    }

}
