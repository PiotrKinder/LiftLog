using Application.Base;
using DTO.Contracts.Stats.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Text.Json;

namespace Application.Stats
{
    public class GetStats
    {
        public class Query : IRequest<List<GetExerciseUnitListItemQuery>>
        {
            public Guid Id { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, List<GetExerciseUnitListItemQuery>>
        {

            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task<List<GetExerciseUnitListItemQuery>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = await GetUserId();

                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

                if (user == null)
                {
                    throw new KeyNotFoundException("User not found.");
                }

                var exercise = await _context.Exercises.FirstOrDefaultAsync(e => e.Id == request.Id && e.User == user);

                if (exercise == null)
                {
                    throw new KeyNotFoundException("Exercise not found.");
                }

                var stats = await _context.Statistics.FirstOrDefaultAsync(s => s.Exercise == exercise);

                if (stats?.DataStat == null)
                {
                    throw new KeyNotFoundException("Stats not found or DataStat is null.");
                }

                return JsonSerializer.Deserialize<List<GetExerciseUnitListItemQuery>>(stats.DataStat) ?? throw new InvalidOperationException("Failed to deserialize StatsModel.");
            }
        }
    }
}
