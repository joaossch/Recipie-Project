using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Service;
using Models;
using Microsoft.AspNetCore.Session; 


namespace ProjectRazer.Pages
{

    public class UserProfileModel : PageModel
    {
      
        public Models.User user { get; set; }  
        
        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Username { get; set; }

        

        private int UserID { get; set; }

        public  IActionResult OnGet()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {

                return RedirectToPage("/User/User");

            }
           
                GetUserDetails((int)userId);
           
           
            return Page();  
        }






        public IActionResult OnPostRedirectSettings()
        {
            // Obt�m o userId da sess�o
            int? userId = HttpContext.Session.GetInt32("UserId");

            // Verifica se o userId � nulo antes de configurar novamente na sess�o
            if (userId.HasValue)
            {
                // Define o userId na sess�o (sem nulo)
                HttpContext.Session.SetInt32("UserId", userId.Value);
            }

            // Redireciona para a p�gina de configura��es do usu�rio
            return new RedirectToPageResult("/User/UserSettings");
        }


        public IActionResult OnPostRedirectAccount()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                return RedirectToPage("/User/UserProfile");
            }
            return RedirectToPage("/User/Login"); // Redireciona para a p�gina de login, se o userId n�o estiver dispon�vel
        }

        private void GetUserDetails(int id)
        {

            UserService userService = new UserService();
            // Obt�m os dados do usu�rio com base no ID
            (Name, Email, Username) = userService.GetUserInfoById(id);
        }
    }
}