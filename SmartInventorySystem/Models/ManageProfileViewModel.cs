namespace SmartInventorySystem.Models;

using System.ComponentModel.DataAnnotations;

public class ManageProfileViewModel
{
    [Required(ErrorMessage = "Full Name is required.")]
    public string FullName { get; set; }

    [Phone(ErrorMessage = "Please enter a valid phone number or email.")]
    public string ContactInfo { get; set; }

    public string PreferredCategory { get; set; }
}