using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class EvolutionStageDto
    {
        public int PokemonID { get; set; }
        public int GroupID { get; set; }
        public int StageOrder { get; set; }
    }


}
