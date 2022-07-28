using api_rpg.Models;

namespace api_rpg.Services.CharacterService
{
	public interface ICharacterService
    {
        List<Character> GetAllCharacters();
        Character GetCharacterById(int id);
        Character AddCharacter(Character newCharacter);
    }
}