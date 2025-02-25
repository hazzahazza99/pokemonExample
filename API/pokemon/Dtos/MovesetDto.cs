using System.ComponentModel.DataAnnotations;

namespace Pokemon.Dtos
{
    public class MovesetDto
    {
        public int MoveID { get; set; }
        public string MoveName { get; set; }
    }
}
