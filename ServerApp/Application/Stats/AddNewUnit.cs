using Application.Base;
using DTO.Contracts.Stats;
using DTO.Contracts.Stats.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Text.Json;

namespace Application.Stats
{
    public class AddNewUnit
    {
        public class Command : IRequest
        {
            public Guid ExerciseId { get; set; }
            public CreateExerciseUnitCommand ExerciseUnit { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Command>
        {
            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var userId = await GetUserId();
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }
                var exerciseId = request.ExerciseId;
                var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId && e.User == user); ;
                if (exercise == null)
                {
                    throw new KeyNotFoundException("Exercise not existe.");
                }
                if (exercise.AllowExtraSet == false && request.ExerciseUnit.ExtraSet != null)
                {
                    throw new Exception("Extra set is not allowed.");
                }
                if (exercise.Sets != request.ExerciseUnit.ExerciseSet.Count)
                {
                    throw new Exception("The number of sets in the request does not match the existing exercise sets.");
                }
                var newUnit = new ExerciseUnitModel()
                {
                    Id = Guid.NewGuid(),
                    SessionDate = request.ExerciseUnit.SessionDate,
                    ExerciseSet = request.ExerciseUnit.ExerciseSet,
                    ExtraSet = request.ExerciseUnit.ExtraSet,
                };
                var statistic = await _context.Statistics.FirstOrDefaultAsync(s => s.Exercise == exercise);
                if (statistic == null)
                {
                    var newStat = new List<ExerciseUnitModel> { newUnit };

                    var newStatistic = new Domain.Statistic
                    {
                        Id = Guid.NewGuid(),
                        DataStat = JsonSerializer.Serialize(newStat),
                        Exercise = exercise,
                        User = user
                    };

                    await _context.Statistics.AddAsync(newStatistic);
                }
                else
                {
                    var dataStat = JsonSerializer.Deserialize<List<ExerciseUnitModel>>(statistic.DataStat);
                    dataStat.Add(newUnit);
                    statistic.DataStat = JsonSerializer.Serialize(dataStat);
                }
                await _context.SaveChangesAsync();

            }
        }
    }
}
