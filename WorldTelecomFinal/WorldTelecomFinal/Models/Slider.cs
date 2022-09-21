using System.ComponentModel.DataAnnotations;

namespace WorldTelecomFinal.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Image { get; set; }
        [Required, StringLength(maximumLength: 1024)]
        public string RedirectUrl { get; set; }
    }
}
