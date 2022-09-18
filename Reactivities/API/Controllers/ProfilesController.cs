
using Application.Profiles;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProfilesController : BaseApiController
    {
        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            return HandleResult(await Mediator.Send(new Details.Query { Username = username }));
        }

        [HttpPut]
        public async Task<ActionResult<Unit>> Edit(Edit.Command command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("{username}/activities")]
        public async Task<IActionResult> GetUserActivities(string username,
            string predicate)
        {
            return HandleResult(await Mediator.Send(new ListActivities.Query { Username = username, Predicate = predicate }));
        }
    }
}
