using Application.Exercise;
using DTO.Contracts.Exercise.Commands;
using DTO.Contracts.Exercise.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class ExerciseController : BaseApiController
    {
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateExerciseCommand request)
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

        [HttpGet("getAll")]
        public async Task<ActionResult<List<GetExerciseListItemQuery>>> GetUserExercises()
        {
            return await Mediator.Send(new GetUserExercises.Query());
        }

        [HttpGet("get/{id}")]
        public async Task<ActionResult<GetExerciseQuery>> GetExercise(Guid id)
        {
            return await Mediator.Send(new GetExercise.Query { Id = id });
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditExercise(Guid id, EditExerciseCommand editExerciseRequest)
        {
            try
            {
                await Mediator.Send(new EditExercise.Command { Id = id, data = editExerciseRequest });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
