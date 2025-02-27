using AutoMapper;
using Pokemon.Dtos;
using Pokemon.Models;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {
        CreateMap<PokemonData, PokemonFullDto>()
            .ForMember(dest => dest.Types, opt => opt.MapFrom(src => src.PokemonTypes.Select(pt => pt.PokeType.TypeName)))
            .ForMember(dest => dest.Moves, opt => opt.MapFrom(src => src.Moves.Select(m => m.Move.MoveName)))
            .ForMember(dest => dest.Regions, opt => opt.MapFrom(src => src.Regions.Select(r => r.Region.RegionName)))
            .ForMember(dest => dest.EvolutionGroup, opt => opt.MapFrom(src => src.EvolutionGroup));



        CreateMap<Trainer, TrainerDto>();
        CreateMap<EvolutionGroup, EvolutionGroupDto>();
        CreateMap<EvolutionStage, EvolutionStageDto>();
        CreateMap<PokemonData, SimplePokemonDto>();
    }
}