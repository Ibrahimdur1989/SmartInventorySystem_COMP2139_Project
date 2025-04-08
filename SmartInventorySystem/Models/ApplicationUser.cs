namespace DefaultNamespace;

using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class ApplicationUser : IdentityUser
{
    [Required]
    public string FullName { get; set; }

    public string ContactInfo { get; set; }

    public string PreferredCategory { get; set; }
}
