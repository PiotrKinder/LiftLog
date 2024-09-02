using DTO.Contracts.Exercise;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Security.Claims;


namespace Application.Exercise
{
    public class GetUserExercise
    {
        public class Query : IRequest<List<GetUserExerciseResponse>>
        {
        }

        public class Handler : IRequestHandler<Query, List<GetUserExerciseResponse>>
        {
            private readonly DataContext _context;
            private readonly IHttpContextAccessor _httpContext;
            public Handler(DataContext context, IHttpContextAccessor httpContext)
            {
                _context = context;
                _httpContext = httpContext;
            }

            public async Task<List<GetUserExerciseResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var email = _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                return await this._context.Exercises.Where(e => e.User.Email == email).Select(e => new GetUserExerciseResponse
                {
                    Id = e.Id,
                    Name = e.Name,
                    Icon = e.Icon,
                }).ToListAsync();
            }
        }



    }
}
