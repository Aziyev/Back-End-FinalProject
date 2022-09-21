using System.ComponentModel.DataAnnotations;

namespace WorldTelecomFinal.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [Required, StringLength(maximumLength: 255)]
        public string Key { get; set; }
        [Required, StringLength(maximumLength: 4000)]
        public string Value { get; set; }
    }
}
