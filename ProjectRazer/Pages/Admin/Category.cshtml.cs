using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class CategoryModel : PageModel
    {
        private readonly CategoryService service;
        private readonly UserService userService;

        public List<Category> CategoriesList { get; set; }
        [BindProperty]
        public string Name { get; set; }

        public string Message { get; set; }

        public CategoryModel()
        {
            service = new CategoryService();
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

            
            LoadCategories();

            return Page();
        }

        private void LoadCategories()
        {
            CategoriesList = service.CategoryList();
        }

        public IActionResult OnPost()
        {
            var category = new Category
            {
                Name = Name,
            };

            try
            {
                bool success = service.Insert(category);

                if (success)
                {
                    Message = "Sucess!";
                    LoadCategories();
                }
                else
                {
                    Message = "Error .";
                }
            }
            catch (Exception)
            {
                Message = "An error occurred while registering the category";
            }

            return Page();
        }

        public IActionResult OnPostEdit(int id)
        {
           
            return RedirectToPage("/Admin/CategoryEdit", new { id });
        }
    }
}

