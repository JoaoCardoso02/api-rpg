using api_rpg.Models;
using api_rpg.Dtos.Characters;
using AutoMapper;

namespace api_rpg.Services.CharacterService
{
	public class CharacterService : ICharacterService
	{
		private static List<Character> characters = new List<Character> {
			new Character(),
			new Character { Id = 1, Name = "Sam" }
		};

		private readonly IMapper _mapper;

		public CharacterService(IMapper mapper)
		{
			_mapper = mapper;
		}

		public async Task<ServiceResponse<GetCharacterDto>> AddCharacter(AddCharacterDto newCharacter)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDto>();

			Character character = _mapper.Map<Character>(newCharacter);
			character.Id = characters.Max(character => character.Id) + 1;

			characters.Add(character);
			serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.Last());

			return serviceResponse;
		}

		public async Task<ServiceResponse<bool>> DeleteCharacter(int id)
		{
			var response = new ServiceResponse<bool>();

			try {
				var character = characters.First(character => character.Id == id);

				characters.Remove(character);

				response.Data = true;
			} catch (Exception error) {
				response.Success = false;
				response.Message = error.Message;
				response.Data = false;
			}

			return response;
		}

		public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
		{
			return new ServiceResponse<List<GetCharacterDto>>
			{
				Data = characters.Select(character => _mapper.Map<GetCharacterDto>(character)).ToList()
			};
		}

		public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
		{
			var serviceResponse = new ServiceResponse<GetCharacterDto>();
			var character = characters.FirstOrDefault(character => character.Id == id);
			serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

			return serviceResponse;
		}

		public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
		{
			var response = new ServiceResponse<GetCharacterDto>();

			try {
				var character = characters.FirstOrDefault(character => character.Id == updatedCharacter.Id);

				_mapper.Map(updatedCharacter, character);

				response.Data = _mapper.Map<GetCharacterDto>(character);
			} catch (Exception error) {
				response.Success = false;
				response.Message = error.Message;
			}

			return response;
		}
	}
}