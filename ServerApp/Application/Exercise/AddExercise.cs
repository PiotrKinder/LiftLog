using Application.Base;
using DTO.Contracts.Exercise;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Exercise
{
    public class AddExercise
    {
        public class Command : IRequest
        {
            public AddExerciseRequest AddExerciseRequest { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command>
        {
            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var userId = await GetUserId();
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    throw new Exception("User not found.");
                }

                var exercise = new Domain.Exercise()
                {
                    Id = Guid.NewGuid(),
                    Name = request.AddExerciseRequest.Name,
                    Icon = request.AddExerciseRequest.Icon,
                    Sets = request.AddExerciseRequest.Sets,
                    AllowExtraSet = request.AddExerciseRequest.ExtraSet,
                    User = user,
                };
                _context.Exercises.Add(exercise);
                await _context.SaveChangesAsync();
            }
        }
    }
}
