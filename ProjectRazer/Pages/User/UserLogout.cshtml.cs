using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ProjectRazer.Pages.User
{
    public class UserLogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Remove o UserId da sess�o
            HttpContext.Session.Remove("UserId");

            // Redireciona para a p�gina inicial ou de login
            return RedirectToPage("/Index");
        }
    }
}
