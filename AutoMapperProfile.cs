using AutoMapper;
using api_rpg.Models;
using api_rpg.Dtos.Characters;

namespace api_rpg
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<Character, GetCharacterDto>();
			CreateMap<AddCharacterDto, Character>();
			CreateMap<UpdateCharacterDto, Character>();
		}
	}
}