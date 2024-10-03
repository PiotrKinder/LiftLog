using Application.Base;
using DTO.Contracts.Exercise.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Exercise
{
    public class EditExercise
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public EditExerciseCommand data { get; set; }
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

                var exercise = await _context.Exercises.FirstOrDefaultAsync(x => x.User.Id == userId && x.Id == request.Id);
                if (exercise == null)
                {
                    throw new Exception("Exercise not found.");
                }
                exercise.Name = request.data.Name;
                exercise.Icon = request.data.Icon;
                exercise.Sets = request.data.Sets;
                exercise.AllowExtraSet = request.data.ExtraSet;
                await _context.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
