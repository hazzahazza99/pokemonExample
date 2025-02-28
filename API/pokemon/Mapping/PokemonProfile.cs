using AutoMapper;
using Pokemon.Dtos;
using Pokemon.Models;

public class PokemonProfile : Profile
{
    public PokemonProfile()
    {

        CreateMap<PokemonData, PokemonFullDto>()
            .ForMember(dest => dest.Types, opt => opt.MapFrom(src =>
                src.PokemonTypes.Select(pt => pt.PokeType)))
            .ForMember(dest => dest.Moves, opt => opt.MapFrom(src =>
                src.Moves.Select(m => m.Move)))
            .ForMember(dest => dest.Regions, opt => opt.MapFrom(src =>
                src.Regions.Select(r => r.Region)))
            .ReverseMap()
            .ForMember(dest => dest.PokemonTypes, opt => opt.Ignore())
            .ForMember(dest => dest.Moves, opt => opt.Ignore())
            .ForMember(dest => dest.Regions, opt => opt.Ignore())
            .ForMember(dest => dest.EvolutionGroup, opt => opt.Ignore())
            .ForMember(dest => dest.Trainer, opt => opt.Ignore());


        CreateMap<PokemonType, PokemonTypeDto>().ReverseMap();
        CreateMap<Moveset, MovesetDto>().ReverseMap();
        CreateMap<PokemonRegion, PokemonRegionDto>().ReverseMap();
        CreateMap<EvolutionStage, EvolutionStageDto>().ReverseMap();


        CreateMap<Picture, PictureDto>().ReverseMap();
        CreateMap<Trainer, TrainerDto>().ReverseMap();
        CreateMap<Move, MoveDto>().ReverseMap();
        CreateMap<Region, RegionDto>().ReverseMap();
        CreateMap<PokeType, PokeTypeDto>().ReverseMap();
        CreateMap<EvolutionGroup, EvolutionGroupDto>().ReverseMap();
    }
}