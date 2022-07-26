using System;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spice_shelf.Models;
using spice_shelf.Services;

namespace spice_shelf.Controllers
{
    [ApiController]
    [Route(("api/[controller]"))]
    public class StepController : ControllerBase
    {
        private readonly StepsService _ss;
        public StepController(StepsService ss)
        {
            _ss = ss;
        }

        [Authorize]
        [HttpPost("{recipeId}")]
        public async Task<ActionResult<Step>> Create(int recipeId, [FromBody] Step stepData)
        {
            try
            {
                stepData.recipeId = recipeId;
                Account userInfo = await HttpContext.GetUserInfoAsync<Account>();
                Step step = _ss.Create(stepData, userInfo.Id, recipeId);
                return Ok(step);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}