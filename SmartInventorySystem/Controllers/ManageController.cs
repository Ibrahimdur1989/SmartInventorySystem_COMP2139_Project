using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[Authorize]
public class ManageController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    public ManageController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    // GET: /Manage/Profile
    public async Task<IActionResult> Profile()
    {
        var user = await _userManager.GetUserAsync(User);
        var model = new ManageProfileViewModel
        {
            FullName = user.FullName,
            ContactInfo = user.ContactInfo,
            PreferredCategory = user.PreferredCategory
        };
        return View(model);
    }

    // POST: /Manage/Profile
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Profile(ManageProfileViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var user = await _userManager.GetUserAsync(User);
        user.FullName = model.FullName;
        user.ContactInfo = model.ContactInfo;
        user.PreferredCategory = model.PreferredCategory;

        var result = await _userManager.UpdateAsync(user);

        if (result.Succeeded)
        {
            TempData["Success"] = "Profile updated successfully!";
            return RedirectToAction("Profile");
        }

        foreach (var error in result.Errors)
            ModelState.AddModelError("", error.Description);

        return View(model);
    }
}