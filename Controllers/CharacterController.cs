using Microsoft.AspNetCore.Mvc;
using api_rpg.Models;
using api_rpg.Services.CharacterService;
using api_rpg.Dtos.Characters;

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
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get() {
			return Ok(await _characterService.GetAllCharacters());
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id) {
			return Ok(await _characterService.GetCharacterById(id));
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacter(AddCharacterDto character) {
			return Ok(await _characterService.AddCharacter(character));
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter) {
			return Ok(await _characterService.UpdateCharacter(updatedCharacter));
		}
	}
}