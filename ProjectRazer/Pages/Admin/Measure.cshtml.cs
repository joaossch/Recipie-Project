using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class MeasureModel : PageModel
    {
        private readonly MeasureService service;
        private readonly UserService userService;

        public List<Measure> MeasuresList { get; set; }
        [BindProperty]
        public string Name { get; set; }

        public string Message { get; set; }

        public MeasureModel()
        {
            service = new MeasureService();
            userService = new UserService();
        }

        public IActionResult OnGet()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/User/User");
            }

            int userIdValue = userId.Value;
            bool isAdmin = userService.IsAdmin(userIdValue);
            HttpContext.Session.SetInt32("IsAdmin", isAdmin ? 1 : 0);

            if (HttpContext.Session.GetInt32("IsAdmin") == 0)
            {
                return RedirectToPage("/User/User");
            }

            
            LoadMeasures();

            return Page();
        }

        private void LoadMeasures()
        {
            MeasuresList = service.MeasureList();
        }

        public IActionResult OnPost()
        {
            var measure = new Measure
            {
                Name = Name,
            };

            try
            {
                bool success = service.Insert(measure);

                if (success)
                {
                    Message = "Sucess!";
                    LoadMeasures();
                }
                else
                {
                    Message = "Error inserting the measure.";
                }
            }
            catch (Exception)
            {
                Message = "An error occurred while registering the measure.";
            }

            return Page();
        }

        public IActionResult OnPostEdit(int id)
        {
            
            return RedirectToPage("/Admin/MeasureEdit", new { id });
        }
    }
}

