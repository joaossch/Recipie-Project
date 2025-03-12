using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;
using Microsoft.AspNetCore.Session;
namespace ProjectRazer.Pages.User
{
    public class UserSettingsModel : PageModel
    {
        public Models.User user { get; set; }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Username { get; set; }

        public string Message { get; set; }



        private int UserID { get; set; }

        public IActionResult OnGet()
        {

            int? userId = HttpContext.Session.GetInt32("UserId");



            GetUserDetails((int)userId);


            return Page();
        }



        private void GetUserDetails(int id)
        {

            UserService userService = new UserService();
            // Obt�m os dados do usu�rio com base no ID
            (Name, Email, Username) = userService.GetUserInfoById(id);


        }

        public IActionResult OnPost()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            int userIdValue = (int)userId;
            UserService userService = new UserService();




            try
            {
                // Tenta inserir o usu�rio na base de dados
                bool certo = userService.Update(userIdValue, Name, Email);

                if (certo)
                {

                    Message = "Usu�rio cadastrado com sucesso!";
                    return Page();
                }
                else
                {
                    Message = "Erro ao cadastrar usu�rio.";
                    return Page();
                }
            }
            catch (Exception ex)
            {


                Message = "Ocorreu um erro ao cadastrar o usu�rio.";
                return Page();
            }

        }
        

        /// <summary>
        ///  Redirect Options 
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPostRedirectAccount()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                return RedirectToPage("/User/UserProfile");
            }
            return RedirectToPage("/User/Login"); // Redireciona para a p�gina de login, se o userId n�o estiver dispon�vel
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

        public IActionResult OnPostRedirectSecurity()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId.HasValue)
            {
                return RedirectToPage("/User/UserSecurity");
            }
            return RedirectToPage("/User/Login"); // Redireciona para a p�gina de login, se o userId n�o estiver dispon�vel
        }




    }
}
