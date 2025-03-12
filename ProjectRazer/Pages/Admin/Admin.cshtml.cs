using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class AdminModel : PageModel
    {
        UserService userService = new UserService();   
         public  IActionResult OnGet()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");
            
            if (userId == null)
            {

                return RedirectToPage("/User/User");

            }
            int userIdValue = userId.Value;
            bool isAdmin = userService.IsAdmin(userIdValue);
            HttpContext.Session.SetInt32("IsAdmin", isAdmin ? 1 : 0);
            if(HttpContext.Session.GetInt32("IsAdmin") == 0)
            {
                return RedirectToPage("/User/User");

            }


            return Page();  
        }




        public IActionResult OnPostRedirectProducts()
        {
            return RedirectToPage("/Admin/Products");
        }


        public IActionResult OnPostRedirectMeasure()
        {
            return RedirectToPage("/Admin/Measure");
        }

        public IActionResult OnPostRedirectDifficulty()
        {
            return RedirectToPage("/Admin/Difficulty");
        }
        public IActionResult OnPostRedirectCategory()
        {
            return RedirectToPage("/Admin/Category");
        }
    }
}
