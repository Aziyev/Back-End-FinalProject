using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WorldTelecomFinal.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
        public string SurName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
