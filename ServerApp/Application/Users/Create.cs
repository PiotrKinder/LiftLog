using Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts.DTO.User;

namespace Application.Users
{
    public  class Create
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
