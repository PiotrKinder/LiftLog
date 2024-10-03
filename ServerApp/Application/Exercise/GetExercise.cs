using Application.Base;
using DTO.Contracts.Exercise.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Exercise
{
    public class GetExercise
    {
        public class Query : IRequest<GetExerciseQuery>
        {
            public Guid Id { get; set; }
        }

        public class Handler : BaseHandler, IRequestHandler<Query, GetExerciseQuery>
        {

            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task<GetExerciseQuery> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = GetUserId().Result;
                var data = await this._context.Exercises.FirstOrDefaultAsync(e => e.User.Id == userId && e.Id == request.Id);
                return new GetExerciseQuery() { Id = data.Id, Name = data.Name, Icon = data.Icon, Sets = data.Sets, ExtraSet = data.AllowExtraSet };
            }
        }
    }
}
