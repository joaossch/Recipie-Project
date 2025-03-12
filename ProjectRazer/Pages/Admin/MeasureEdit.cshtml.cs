using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class MeasureEditModel : PageModel
    {
        private readonly MeasureService service;

        [BindProperty]
        public string Name { get; set; }
        public string Message { get; set; }

        public MeasureEditModel()
        {
            service = new MeasureService();
        }

        public IActionResult OnGet(int id)
        {

            int id2 = id;


            if (id == null)
            {
                Message = "An error occurred while registering the user.";
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {

            bool sucesso = service.Update(id, Name);


            if (sucesso)
            {
                Message = "Measure updated successfully!";
                return RedirectToPage("/Admin/Measure");
            }
            else
            {
                Message = "Error to update.";
                return Page();
            }
        }
    }
}
