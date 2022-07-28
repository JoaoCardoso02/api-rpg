using Microsoft.AspNetCore.Mvc;
using api_rpg.Models;

namespace api_rpg.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character> {
					new Character(),
					new Character { Id = 1, Name = "Sam" }
				};

				[HttpGet("GetAll")]
				public ActionResult<List<Character>> Get() {
					return Ok(characters);
				}

				[HttpGet]
				[Route("{id}")]
				public ActionResult<Character> GetSingle(int id) {
					return Ok(characters.FirstOrDefault(character => character.Id == id));
				}

				[HttpPost]
				public ActionResult<Character> AddCharacter(Character character) {
					characters.Add(character);

					return Ok(characters.Last());
				}
    }
}