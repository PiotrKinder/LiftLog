using Application.Helpers;
using Application.Validators;
using DTO.Contracts.User;
using DTO.DTO;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    internal class ChangePassword
    {
        public class Command : IRequest
        {
            public ChangePasswordRequest ChangePasswordRequest { get; set; }
            public JwtData JwtData { get; set; }
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
                var email = _httpContext.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
                if (user == null || !PasswordVerification.Check(request.ChangePasswordRequest.oldPassword, user.Password))
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
