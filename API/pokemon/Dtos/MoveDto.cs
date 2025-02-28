using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class MoveDto
    {
        public int MoveID { get; set; }
        [Required]
        [StringLength(50)]
        public string MoveName { get; set; } = string.Empty;
        [Range(10, 250)]
        public int MovePower { get; set; }
        [Range(1, 40)]
        public int MovePP { get; set; }
        [Required]
        public int MovePokeTypeID { get; set; }
        public PokeTypeDto? MovePokeType { get; set; }
    }
}
