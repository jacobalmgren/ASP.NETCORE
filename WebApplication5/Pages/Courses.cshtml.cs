using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

[Authorize]
public class CoursesModel : PageModel
{
    public void OnGet()
    {
    }
}
