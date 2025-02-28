using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class PokeTypeDto
    {
        public int PokeTypeID { get; set; }
        [Required]
        public string TypeName { get; set; } = string.Empty;
    }
}
