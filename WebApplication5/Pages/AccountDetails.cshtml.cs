using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations; 
using System.Threading.Tasks;

public class AccountDetailsModel : PageModel
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AccountDetailsModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public class InputModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        [Required]

        public string Bio { get; set; }

        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string PostalCode { get; set; }
    }

    public string UserName { get; private set; }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        UserName = user.UserName;
        Input = new InputModel
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Bio = user.Bio,
            AddressLine1 = user.AddressLine1,
            AddressLine2 = user.AddressLine2,
            City = user.City,
            PostalCode = user.PostalCode
        };

        return Page();
    }

    public async Task<IActionResult> OnPostLogoutAsync(string returnUrl = null)
    {
        await _signInManager.SignOutAsync();
        return LocalRedirect(returnUrl ?? "/");
    }

    public async Task<IActionResult> OnPostUpdateDetailsAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        user.FirstName = Input.FirstName;
        user.LastName = Input.LastName;
        user.Email = Input.Email;
        user.PhoneNumber = Input.PhoneNumber;
        user.Bio = Input.Bio;

        var detailsUpdateResult = await _userManager.UpdateAsync(user);
        if (!detailsUpdateResult.Succeeded)
        {
            foreach (var error in detailsUpdateResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostUpdateAddressAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
        }

        user.AddressLine1 = Input.AddressLine1;
        user.AddressLine2 = Input.AddressLine2;
        user.City = Input.City;
        user.PostalCode = Input.PostalCode;

        var addressUpdateResult = await _userManager.UpdateAsync(user);
        if (!addressUpdateResult.Succeeded)
        {
            foreach (var error in addressUpdateResult.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }

        return RedirectToPage();
    }
}
