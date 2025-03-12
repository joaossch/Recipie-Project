using Models;
using System.Data;
using System.Data.SqlClient;
using Repository; 

namespace Service
{
    public class RecipesService
    {
        public string _connectionString;

       
        public RecipesService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }
        public bool Insert(Recipes recipes)
        {
           

            if (string.IsNullOrWhiteSpace(recipes.Title))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(recipes.PreparationMethod))
            {
                return false;
            }
               
            RecipesService recipeService = new RecipesService();  

            recipeService.Insert(recipes);
            return true;
        }



      
 












    }
}