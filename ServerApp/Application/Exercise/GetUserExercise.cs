using Application.Base;
using DTO.Contracts.Exercise;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;


namespace Application.Exercise
{
    public class GetUserExercise
    {
        public class Query : IRequest<List<GetUserExerciseResponse>>
        {
        }

        public class Handler : BaseHandler, IRequestHandler<Query, List<GetUserExerciseResponse>>
        {

            public Handler(DataContext context, IHttpContextAccessor httpContext) : base(context, httpContext)
            {
            }

            public async Task<List<GetUserExerciseResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var userId = GetUserId().Result;
                return await this._context.Exercises.Where(e => e.User.Id == userId).Select(e => new GetUserExerciseResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Icon = e.Icon,
                }).ToListAsync();
            }
        }



    }
}
