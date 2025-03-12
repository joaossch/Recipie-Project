using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;
using Service;

namespace ProjectRazer.Pages.Admin
{
    public class ProductsModel : PageModel
    {
        private readonly IngredientService service;
        private readonly UserService userService;

        public List<Ingredients> IngredientsList { get; set; }
        [BindProperty]
        public string Name { get; set; }    

        public string Message {  get; set; }
        public ProductsModel()
        {
            service = new IngredientService();
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

            
            LoadIngredients();

            return Page();
        }

        private void LoadIngredients()
        {
            IngredientsList = service.IngredientsList();
        }



        public IActionResult OnPost()
        {
            Models.Ingredients ingredients = new Models.Ingredients
            {
                Name = Name,

            };
            try
            {


                bool certo = service.Insert(ingredients);

                if (certo) 
                {

                    Message = "Sucess!";
                    LoadIngredients();
                    return Page();
                }
                else
                {
                    Message = "Error";
                    return Page();
                }
            }
            catch (Exception ex)
            {


                Message = "An error occurred while registering the user.";
                return Page();
            }


        }

        public IActionResult OnPostEdit(int id)
        {
            
            var ingredient = id;

            

            
            return RedirectToPage("/Admin/ProductsEdit", new { id = id });
        }

    }

}
