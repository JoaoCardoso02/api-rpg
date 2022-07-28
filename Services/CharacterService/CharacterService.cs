using api_rpg.Models;

namespace api_rpg.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private static List<Character> characters = new List<Character> {
			new Character(),
			new Character { Id = 1, Name = "Sam" }
		};

		public Character AddCharacter(Character newCharacter)
		{
			characters.Add(newCharacter);
			return characters.Last();
		}

		public List<Character> GetAllCharacters()
		{
			return characters;
		}

		public Character GetCharacterById(int id)
		{
			return characters.FirstOrDefault(character => character.Id == id);
		}
	}
}