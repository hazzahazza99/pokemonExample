using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class EvolutionStageDto
    {
        public int GroupID { get; set; }
        public int StageOrder { get; set; }
        public int PokemonID { get; set; }
    }


}
