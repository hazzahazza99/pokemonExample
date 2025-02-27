namespace Pokemon.Dtos
{
    public class PokemonEditDto
    {
        public string PokemonName { get; set; }
        public int? PictureId { get; set; }
        public EvolutionGroupDto? EvolutionGroup { get; set; }
        public List<int> TypeIds { get; set; }
        public List<int> RegionIds { get; set; }
        public List<EvolutionStageDto> EvolutionStages { get; set; }
    }
}
