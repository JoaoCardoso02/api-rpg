using Microsoft.AspNetCore.Mvc;
using api_rpg.Models;

namespace api_rpg.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
    {
        private static Character knight = new Character();

				[HttpGet]
				public ActionResult<Character> Get() {
					return Ok(knight);
				}
    }
}