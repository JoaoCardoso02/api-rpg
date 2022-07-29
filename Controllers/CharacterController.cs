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
		public async Task<ActionResult<ServiceResponse<List<Character>>>> Get() {
			return Ok(await _characterService.GetAllCharacters());
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<ServiceResponse<Character>>> GetSingle(int id) {
			return Ok(await _characterService.GetCharacterById(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<Character>>> AddCharacter(Character character) {
			return Ok(await _characterService.AddCharacter(character));
		}
	}
}