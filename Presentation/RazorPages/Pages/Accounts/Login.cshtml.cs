using Microsoft.AspNetCore.Mvc;

namespace RazorPages.Pages.Accounts;

public class LoginModel : BasePageModel
{
    [BindProperty] public LoginUser Req { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity?.IsAuthenticated is true) return RedirectToPage("/Index");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await Mediator.Send(Req);
        HttpContext.SignIn(response.AccessToken);
        return RedirectToPage("/Index");
    }
}