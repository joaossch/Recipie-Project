using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class DifficultyEditModel : PageModel
    {
        private readonly DifficultyService service;

        [BindProperty]
        public string Name { get; set; }
        public string Message { get; set; }

        public DifficultyEditModel()
        {
            service = new DifficultyService();
        }

        public IActionResult OnGet(int id)
        {
            int id2 = id;

            if (id == null)
            {
                Message = "An error occurred while editing the difficulty.";
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            bool sucesso = service.Update(id, Name);

            if (sucesso)
            {
                Message = "Difficulty updated successfully!";
                return RedirectToPage("/Admin/Difficulty"); 
            }
            else
            {
                Message = "Error updating the difficulty.";
                return Page();
            }
        }
    }
}
