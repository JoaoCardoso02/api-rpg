using api_rpg.Models;

namespace api_rpg.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private static List<Character> characters = new List<Character> {
			new Character(),
			new Character { Id = 1, Name = "Sam" }
		};

		public async Task<ServiceResponse<Character>> AddCharacter(Character newCharacter)
		{
			var serviceResponse = new ServiceResponse<Character>();
			characters.Add(newCharacter);
			serviceResponse.Data = newCharacter;
			
			return serviceResponse;
		}

		public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
		{
			return new ServiceResponse<List<Character>> { Data = characters };
		}

		public async Task<ServiceResponse<Character>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<Character>();
			var character = characters.FirstOrDefault(character => character.Id == id);
			serviceResponse.Data = character;

			return serviceResponse;
		}
	}
}