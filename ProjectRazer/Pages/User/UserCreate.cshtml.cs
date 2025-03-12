using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service; 

namespace ProjectRazer.Pages
{
    public class UserCreateModel : PageModel
    {
        
        /// <summary>
        /// Propriedades para relacionar com html
        /// </summary>
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]

        public string Email { get; set; } 
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public string Message { get; set; } 

      /// <summary>
      ///  Para poder instanciar um novo usuario 
      /// </summary>
        private UserService userService { get; set; } = new UserService();  

        public Models.User  User { get; set; }  


        public void OnGet()
        {
        
        }


        public IActionResult OnPost()
        {
            // Criação do objeto usuário com os dados do formulário
            Models.User user = new Models.User
            {
                Name = Name,
                Email = Email,
                Username = Username,
                Password = Password // Idealmente, a senha deveria ser hashada
            };

            try
            {
                // Tenta inserir o usuário na base de dados
                bool certo = userService.Insert(user);

                if (certo)
                {
                     
                    Message = "Usuário cadastrado com sucesso!";
                    return Page(); 
                }
                else
                {
                    Message = "Erro ao cadastrar usuário.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                
               
                Message = "Ocorreu um erro ao cadastrar o usuário.";
                return Page();
        }
            }

        public IActionResult OnPostRedirectUser()
        {
            return new RedirectToPageResult("User");
        }



    }



}

