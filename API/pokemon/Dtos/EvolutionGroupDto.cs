using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class EvolutionStageDto
    {
        public int StageOrder { get; set; }
        public SimplePokemonDto Pokemon { get; set; }
    }

    public class SimplePokemonDto
    {
        public int PokemonID { get; set; }
        public string Name { get; set; }
    }

    public class EvolutionGroupDto
    {
        public int GroupID { get; set; }
        public List<EvolutionStageDto> EvolutionStages { get; set; }
    }


}
