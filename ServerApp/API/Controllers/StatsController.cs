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
        [HttpPost("add/exercise={exerciseId}")]
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

        [HttpGet("get/exercise={exerciseId}")]
        public async Task<ActionResult<List<GetExerciseUnitListItemQuery>>> GetStats(Guid exerciseId)
        {
            try
            {
                return await Mediator.Send(new GetStats.Query { Id = exerciseId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("get/last/exercise={exerciseId}")]
        public async Task<ActionResult<GetExerciseUnitItemQuery>> GetLastStats(Guid exerciseId)
        {
            try
            {
                return await Mediator.Send(new GetLastStat.Query { ExerciseId = exerciseId });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


    }
}
