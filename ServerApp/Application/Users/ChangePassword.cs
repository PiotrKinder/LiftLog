using Application.Base;
using Application.Validators;
using DTO.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class ChangePassword
    {
        public class Command : IRequest
        {
            public ChangePasswordRequest ChangePasswordRequest { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command>
        {
            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var userValidator = new UserValidators();
                var userId = GetUserId().Result;
                var user = await _context.Users.Include(e => e.Exercises).SingleOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }
                if (!ChackPassword(request.ChangePasswordRequest.oldPassword, user.Password))
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
