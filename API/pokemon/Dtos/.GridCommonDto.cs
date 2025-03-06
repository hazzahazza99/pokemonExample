using Pokemon.Dtos;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class GridCommonDto
    {
        [Required]
        public List<PokeTypeDto> Types { get; set; }

        [Required]
        public List<MoveDto> Moves { get; set; }

        [Required]
        public List<RegionDto> Regions { get; set; }

        [Required]
        public List<TrainerDto> Trainers { get; set; }
    }

}