using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class Move
    {
        [Key]
        public int MoveID { get; set; }
        public string MoveName { get; set; }
        public string MoveType { get; set; }
        public int MovePP { get; set; }
        public int MovePower { get; set; }

        public virtual ICollection<Moveset> Movesets { get; set; }
    }

}
