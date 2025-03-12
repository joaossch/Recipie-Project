using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace ProjectRazer.Pages.Recipe
{
    public class RecipePageModel : PageModel
    {
        UserService userService = new UserService();
        public IActionResult OnGet()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {

                return RedirectToPage("/User/User");

            }
            int userIdValue = userId.Value;
            bool isAdmin = userService.IsAdmin(userIdValue);
            HttpContext.Session.SetInt32("IsAdmin", isAdmin ? 1 : 0);
            if (HttpContext.Session.GetInt32("IsAdmin") == 0)
            {
                return RedirectToPage("/User/User");

            }


            return Page();
        }
    }
}
