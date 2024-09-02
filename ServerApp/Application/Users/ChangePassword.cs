using Application.Helpers;
using Application.Validators;
using DTO.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Security.Claims;

namespace Application.Users
{
    public class ChangePassword
    {
        public class Command : IRequest
        {
            public ChangePasswordRequest ChangePasswordRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IHttpContextAccessor _httpContext;
            public Handler(DataContext context, IHttpContextAccessor httpContext)
            {
                _context = context;
                _httpContext = httpContext;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var userValidator = new UserValidators();
                var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var user = await _context.Users.Include(e => e.Exercises).SingleOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }
                if (!PasswordVerification.Check(request.ChangePasswordRequest.oldPassword, user.Password))
                {
                    throw new UnauthorizedAccessException("Invalid old password.");
                }

                userValidator.passwordValidator(request.ChangePasswordRequest.newPassword);

                user.Password = request.ChangePasswordRequest.newPassword;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
