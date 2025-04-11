namespace SmartInventorySystem.Models;

using System.ComponentModel.DataAnnotations;

public class ManageProfileViewModel
{
    [Required]
    public string FullName { get; set; }

    public string ContactInfo { get; set; }

    public string PreferredCategory { get; set; }
}