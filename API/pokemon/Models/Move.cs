using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class Move
    {
        [Key]
        public int MoveID { get; set; }
        public string MoveName { get; set; }
        public int MovePower { get; set; }
        public int MovePP { get; set; }
        public int MovePokeTypeID { get; set; }

        public virtual PokeType MovePokeType { get; set; }
        public virtual ICollection<Moveset> Movesets { get; set; }
    }
}
