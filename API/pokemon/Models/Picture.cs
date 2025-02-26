using System.ComponentModel.DataAnnotations;

namespace Pokemon.Models
{
    public class Picture
    {
        [Key]
        public int PictureID { get; set; }
        public string PicturePath { get; set; }
    }
}
