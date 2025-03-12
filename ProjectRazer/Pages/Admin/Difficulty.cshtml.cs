using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class DifficultyModel : PageModel
    {
        private readonly DifficultyService service;
        private readonly UserService userService;

        public List<Difficulty> DifficultiesList { get; set; }
        [BindProperty]
        public string Name { get; set; }

        public string Message { get; set; }

        public DifficultyModel()
        {
            service = new DifficultyService();
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

            LoadDifficulties();

            return Page();
        }

        private void LoadDifficulties()
        {
            DifficultiesList = service.DifficultyList();
        }

        public IActionResult OnPost()
        {
            var difficulty = new Difficulty
            {
                Name = Name,
            };

            try
            {
                bool success = service.Insert(difficulty);

                if (success)
                {
                    Message = "Sucess!";
                    LoadDifficulties();
                }
                else
                {
                    Message = "Error inserting the difficulty.";
                }
            }
            catch (Exception)
            {
                Message = "An error occurred while registering the difficulty.";
            }

            return Page();
        }

        public IActionResult OnPostEdit(int id)
        {
            
            return RedirectToPage("/Admin/DifficultyEdit", new { id });
        }
    }
}
