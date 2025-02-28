using Pokemon.Dtos;
using System.ComponentModel.DataAnnotations;

public class PokemonFullDto
{
    public int PokemonID { get; set; }

    [Required]
    public string PokemonName { get; set; }

    public int? PokemonPictureID { get; set; }
    public int? PokemonTrainerID { get; set; } 
    public int? EvolutionGroupID { get; set; }

    public PictureDto? PokemonPicture { get; set; }

    public TrainerDto? Trainer { get; set; }

    public List<PokeTypeDto> Types { get; set; } = new();

    public List<MoveDto> Moves { get; set; } = new();

    public List<RegionDto> Regions { get; set; } = new();

    public EvolutionGroupDto? EvolutionGroup { get; set; }
    public List<EvolutionStageDto> EvolutionStages { get; set; } = new();
}