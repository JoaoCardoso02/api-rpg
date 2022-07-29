using api_rpg.Models;

namespace api_rpg.Services.CharacterService
{
	public interface ICharacterService
    {
        Task<ServiceResponse<List<Character>>> GetAllCharacters();
        Task<ServiceResponse<Character>> GetCharacterById(int id);
        Task<ServiceResponse<Character>> AddCharacter(Character newCharacter);
    }
}