using Microsoft.AspNetCore.Mvc;
using api_rpg.Models;
using api_rpg.Services.CharacterService;

namespace api_rpg.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CharacterController : ControllerBase
  {
		private ICharacterService _characterService;

		public CharacterController(ICharacterService characterService)
		{
			_characterService = characterService;
		}

		[HttpGet("GetAll")]
		public ActionResult<List<Character>> Get() {
			return Ok(_characterService.GetAllCharacters());
		}

		[HttpGet]
		[Route("{id}")]
		public ActionResult<Character> GetSingle(int id) {
			return Ok(_characterService.GetCharacterById(id));
		}

		[HttpPost]
		public ActionResult<Character> AddCharacter(Character character) {
			return Ok(_characterService.AddCharacter(character));
		}
	}
}