using api_rpg.Models;
using api_rpg.Dtos.Characters;

namespace api_rpg.Services.CharacterService
{
	public interface ICharacterService
    {
        Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters();
        Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
        Task<ServiceResponse<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter);
    }
}