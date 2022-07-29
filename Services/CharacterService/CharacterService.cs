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
	}
}