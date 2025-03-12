using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class CategoryEditModel : PageModel
    {
        private readonly CategoryService service;

        [BindProperty]
        public string Name { get; set; }
        public string Message { get; set; }

        public CategoryEditModel()
        {
            service = new CategoryService();
        }

        public IActionResult OnGet(int id)
        {
            int id2 = id;

            if (id == null)
            {
                Message = "An error occurred while editing the category.";
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
           
            bool sucesso = service.Update(id, Name);

            if (sucesso)
            {
                Message = "Category updated successfully!";
                return RedirectToPage("/Admin/Category"); 
            }
            else
            {
                Message = "Error updating the category.";
                return Page(); 
            }
        }
    }
}
