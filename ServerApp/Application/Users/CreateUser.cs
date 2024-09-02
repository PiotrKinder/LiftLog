using Application.Validators;
using Domain;
using DTO.Contracts.User;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Users
{
    public class CreateUser
    {
        public class Command : IRequest
        {
            public RegisterRequest RegisterRequest { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var hasher = new PasswordHasher<User>();
                var userValidator = new UserValidators();

                userValidator.emailValidator(request.RegisterRequest.Email);
                userValidator.passwordValidator(request.RegisterRequest.Password);
                bool emailExists = await _context.Users.AnyAsync(u => u.Email == request.RegisterRequest.Email);
                if (emailExists)
                {
                    throw new Exception("An account with this email address already exists.");
                }
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Login = request.RegisterRequest.Login,
                    Email = request.RegisterRequest.Email,
                    Created = DateTime.UtcNow,

                };
                user.Password = hasher.HashPassword(user, request.RegisterRequest.Password);
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
