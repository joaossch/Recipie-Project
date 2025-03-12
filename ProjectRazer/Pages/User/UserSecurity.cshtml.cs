using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Microsoft.AspNetCore.Session;
namespace ProjectRazer.Pages.User
{
    public class UserSecurityModel : PageModel
    {
        [BindProperty]
        public string OldPassword { get; set; }
        [BindProperty]
        public string NewPassword { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }

        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Username { get; set; }


        public string Message { get; set; }



        public UserService userService { get; set; } = new UserService();



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
            // Get the user ID from the session
            int? userId = HttpContext.Session.GetInt32("UserId");

            // Check if the user is logged in
            if (userId == null)
            {
                Message = "User not authenticated.";
                return Page();
            }

            int userIdValue = userId.Value; // Safe conversion

            try
            {
                // Validate the new password
                if (!VerifyPassword(OldPassword, NewPassword, ConfirmPassword))
                {
                    Message = "The new password must be different from the old one, and the fields must match.";
                    return Page();
                }

                // Update the password
                bool updateSuccess = userService.UpdatePassword(userIdValue, NewPassword);

                if (updateSuccess)
                {
                    Message = "Password updated successfully.";
                }
                else
                {
                    Message = "Failed to update password. Please try again.";
                }

                return Page();
            }
            catch (Exception ex)
            {
                // Log the error (if logging is implemented)
                Console.WriteLine($"Error updating password: {ex.Message}");

                Message = "An unexpected error occurred. Please try again.";
                return Page();
            }
        }


        public bool VerifyPassword(string oldPassword, string newPassword, string confirmPassword)
        {
            // Verifica se algum dos campos est� vazio ou nulo
            if (string.IsNullOrWhiteSpace(oldPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                return false;
            }

            // Verifica se newPassword e password s�o iguais e diferentes de oldPassword
            return newPassword == confirmPassword && newPassword != oldPassword;
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
                return RedirectToPage("/User/UserProfile");
            }
            return RedirectToPage("/User/Login"); // Redireciona para a p�gina de login, se o userId n�o estiver dispon�vel
        }

    }
}
