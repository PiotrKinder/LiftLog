using Application.Base;
using DTO.Contracts.Exercise.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Exercise
{
    public class GetUserExercises
    {
        public class Query : IRequest<List<GetExerciseListItemQuery>>
        {
        }

        public class Handler : BaseHandler, IRequestHandler<Query, List<GetExerciseListItemQuery>>
        {

            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task<List<GetExerciseListItemQuery>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = GetUserId().Result;
                return await this._context.Exercises.Where(e => e.User.Id == userId).Select(e => new GetExerciseListItemQuery
                {
                    Id = e.Id,
                    Name = e.Name,
                    Icon = e.Icon,
                }).ToListAsync();
            }
        }



    }
}
