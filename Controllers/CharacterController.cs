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
		public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get()
		{
			var response = await _characterService.GetAllCharacters();

			if (response.Data == null)
			{
				return NotFound(response);
			}

			return Ok(response);
		}

		[HttpGet]
		[Route("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
		{
			var response = await _characterService.GetCharacterById(id);

			if (response.Data == null)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPost]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacter(AddCharacterDto character)
		{
			var response = await _characterService.AddCharacter(character);

			if (response.Data == null)
			{
				return BadRequest(response);
			}

			return Ok(response);
		}

		[HttpPut]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
		{
			var response = await _characterService.UpdateCharacter(updatedCharacter);

			if (response.Data == null)
			{
				return NotFound(response);
			}

			return Ok(response);
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> DeleteCharacter(int id)
		{
			var response = await _characterService.DeleteCharacter(id);

			if (!response.Data)
			{
				return NotFound(response);
			}

			return Ok(response);
		}
	}
}