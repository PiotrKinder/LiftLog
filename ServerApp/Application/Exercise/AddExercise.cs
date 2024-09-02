using DTO.Contracts.Exercise;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Security.Claims;

namespace Application.Exercise
{
    public class AddExercise
    {
        public class Command : IRequest
        {
            public AddExerciseRequest AddExerciseRequest { get; set; }
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
                var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                var exercise = new Domain.Exercise()
                {
                    Id = Guid.NewGuid(),
                    Name = request.AddExerciseRequest.name,
                    Icon = request.AddExerciseRequest.icon,
                    Sets = request.AddExerciseRequest.sets,
                    AllowExtraSet = request.AddExerciseRequest.extraSet,
                    User = user,
                };
                _context.Exercises.Add(exercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
