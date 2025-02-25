using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class EvolutionGroup
    {
        [Key]
        public int EvolutionGroupID { get; set; }
        public string? EvolutionGroupName { get; set; }
        public virtual ICollection<Evolution> Evolutions { get; set; }
    }
}