using Application.Base;
using DTO.Contracts.Stats;
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
            public AddNewUnitRequest AddNewUnitRequest { get; set; }
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
                var exerciseId = request.AddNewUnitRequest.exerciseId;
                var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == exerciseId && e.User == user); ;
                if (exercise == null)
                {
                    throw new KeyNotFoundException("Exercise not existe.");
                }
                var newUnit = new ExerciseUnitModel()
                {
                    Id = Guid.NewGuid(),
                    SessionDate = request.AddNewUnitRequest.exerciseUnit.SessionDate,
                    ExerciseSet = request.AddNewUnitRequest.exerciseUnit.ExerciseSet,
                    ExtraSet = request.AddNewUnitRequest.exerciseUnit.ExtraSet,
                };
                var statistic = await _context.Statistics.FirstOrDefaultAsync(s => s.Exercise == exercise);
                if (statistic == null)
                {
                    var newStat = new StatsModel
                    {
                        ExerciseUnits = new List<ExerciseUnitModel> { newUnit }
                    };

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
                    var dataStat = JsonSerializer.Deserialize<StatsModel>(statistic.DataStat);
                    dataStat.ExerciseUnits.Add(newUnit);
                    statistic.DataStat = JsonSerializer.Serialize(dataStat);
                }
                await _context.SaveChangesAsync();

            }
        }
    }
}
