using Akelny.BLL.Errors;
using Akelny.DAL.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Akelny.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuggyController : ControllerBase
    {
        private readonly ApplicationDbContext _Context;

        public BuggyController(ApplicationDbContext Context)
        {
            _Context = Context;
        }
        [HttpGet("notfound")]
        public IActionResult GetNotFoundRequest()
        {
            var thing = _Context.Restaurant.Find(50);
            if (thing == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return Ok();
        }
        [HttpGet("servererror")]
        public IActionResult GetServerError()
        {
            var thing = _Context.Restaurant.Find(50);
            if (thing == null) { return NoContent(); }
            var thingToReturn = thing.ToString();
            return Ok();

        }
        [HttpGet("badRequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest();
        }
        [HttpGet("{id}")]

        public IActionResult GetNotFoundRequest(int id)
        {
            return NotFound();
        }

    }
}
