using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {

    }
}