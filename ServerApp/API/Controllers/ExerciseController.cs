using Application.Exercise;
using DTO.Contracts.Exercise;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ExerciseController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddExerciseRequest request)
        {
            try
            {
                await Mediator.Send(new AddExercise.Command { AddExerciseRequest = request });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get")]
        public async Task<ActionResult<List<GetUserExerciseResponse>>> GetUserExercise(CancellationToken cancellationToken)
        {
            return await this.Mediator.Send(new GetUserExercise.Query(), cancellationToken);
        }
    }
}
