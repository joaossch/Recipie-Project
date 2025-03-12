using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class EditModel : PageModel
    {

        private readonly IngredientService service;

        [BindProperty]
        public string Name { get; set; }
        public string Message { get; set; }


        public EditModel()
        {
            service = new IngredientService();
            
        }
        public IActionResult OnGet(int id)
        {
            int id2 = id;

            
            if (id == null)
            {
                Message = "Ocorreu um erro ao cadastrar o usuário.";
            }

            return Page();
        }


        public IActionResult OnPost(int id)
        {
            
            bool sucesso = service.Update(id, Name);

            
            if (sucesso)
            {
                Message = "Update Successful ";
                return RedirectToPage("/Admin/Products"); 
            }
            else
            {
                Message = "Erro when update .";
                return Page(); 
            }
        }




    }
} 
