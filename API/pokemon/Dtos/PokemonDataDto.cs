namespace Pokemon.Dtos
{
    public class PokemonDataDto
    {
        public int PokemonID { get; set; }
        public string PokemonName { get; set; }
        public int? TrainerID { get; set; }
        public int? PictureID { get; set; }
        public string? PictureURL { get; set; } 
        public TrainerDto Trainer { get; set; }
        public ICollection<PokemonRegionDto> PokemonRegions { get; set; }
        public ICollection<MovesetDto> Movesets { get; set; }
        public EvolutionGroupDto EvolutionGroup { get; set; }
    }
}
