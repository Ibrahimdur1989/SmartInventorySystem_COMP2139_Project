using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SmartInventorySystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Contact Info")]
        public string? ContactInfo { get; set; }

        [Display(Name = "Preferred Category")]
        public string? PreferredCategory { get; set; }
    }
}