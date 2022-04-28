using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RazorPages.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        [BindProperty] public string UserName { get; set; }
        [BindProperty] public string Password { get; set; }

        public void OnGet()
        {
        }
    }
}
