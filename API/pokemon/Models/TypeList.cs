using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pokemon.Models
{
    public class TypeList
    {
        public int TypeListID { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<PokemonType> PokemonTypes { get; set; }
    }

}
