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
        [HttpPost("addExercise")]
        public async Task<IActionResult> AddExercise([FromBody] CreateExerciseCommand request)
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

        [HttpGet("getAllExercises")]
        public async Task<ActionResult<List<GetExerciseListItemQuery>>> GetUserExercises()
        {
            try
            {
                return await Mediator.Send(new GetUserExercises.Query());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("getExercise/{id}")]
        public async Task<ActionResult<GetExerciseQuery>> GetExercise(Guid id)
        {
            try
            {
                return await Mediator.Send(new GetExercise.Query { Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("editExercise/{id}")]
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
