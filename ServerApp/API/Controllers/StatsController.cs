using Application.Stats;
using DTO.Contracts.Stats.Commands;
using DTO.Contracts.Stats.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class StatsController : BaseApiController
    {
        [HttpPost("add/{exerciseId}/stat")]
        public async Task<IActionResult> SaveStats([FromBody] CreateExerciseUnitCommand request, Guid exerciseId)
        {
            try
            {
                await Mediator.Send(new AddNewUnit.Command { ExerciseId = exerciseId, ExerciseUnit = request });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get/exercise={id}")]
        public async Task<ActionResult<List<GetExerciseUnitListItemQuery>>> GetStats(Guid id)
        {
            return await Mediator.Send(new GetStats.Query { Id = id });
        }


    }
}
