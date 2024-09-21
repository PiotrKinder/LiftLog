using Application.Stats;
using DTO.Contracts.Stats;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class StatsController : BaseApiController
    {
        [HttpPost("save")]
        public async Task<IActionResult> SaveStats([FromBody] AddNewUnitRequest request)
        {
            try
            {
                await Mediator.Send(new AddNewUnit.Command { AddNewUnitRequest = request });
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
