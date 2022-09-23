using System.ComponentModel.DataAnnotations;

namespace WorldTelecomFinal.Areas.Manage.ViewModels.AccountViewModel
{
    public class LoginVM
    {

        [Required]
        [StringLength(255)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RemindMe { get; set; }
    }
}
