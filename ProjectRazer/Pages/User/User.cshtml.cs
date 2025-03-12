using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;
using Models;
namespace ProjectRazer.Pages;

public class UserModel : PageModel
{
    

    // Usar [BindProperty] para que Razor Pages ligue automaticamente esses valores do formulário
    [BindProperty]
    public string Username { get; set; }

    [BindProperty]
    public string Password { get; set; }

    public string Message { get; set; }



    public UserService userService { get; set; } = new UserService();


    // Método para processar o POST quando o formulário é enviado
    public IActionResult OnPost()
    {
        string _correctUsername = this.Username;
        string _correctPassword = this.Password;
        if (userService.Login(_correctUsername, _correctPassword))
        {
            UserService userService = this.userService;
            int userId = userService.UserId(this.Username, this.Password);
            int userProtectId = userId;
            bool isAdmin = userService.IsAdmin(userId);
            HttpContext.Session.SetInt32("UserId", userId);
            HttpContext.Session.SetInt32("IsAdmin", isAdmin ? 1 : 0);

            Message = "Sua senha está correta.";
            return new RedirectToPageResult("/Index");

        }
        else
        {
            Message = "Login inválido. Tente novamente."; // Exibe uma mensagem caso o login falhe
            return Page(); // Retorna a mesma página com a mensagem de erro
        }
    }


    public IActionResult OnPostCreateNewUser()
    {
        return new RedirectToPageResult("UserCreate");
    }
}