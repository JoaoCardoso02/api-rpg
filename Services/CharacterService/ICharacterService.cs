using api_rpg.Models;

namespace api_rpg.Services.CharacterService
{
	public interface ICharacterService
    {
        Task<List<Character>> GetAllCharacters();
        Task<Character> GetCharacterById(int id);
        Task<Character> AddCharacter(Character newCharacter);
    }
}