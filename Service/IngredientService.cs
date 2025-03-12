using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Service
{
    public class IngredientService
    {
        public string _connectionString;
        IngredientsRepository repository= new IngredientsRepository();
       
        public IngredientService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }

        public bool Insert(Ingredients ingredients)
        {


            if (string.IsNullOrWhiteSpace(ingredients.Name))
            {

                return false;
            }
           



            repository.Insert(ingredients);
            return true;
        }

        public bool CheckIngredients(string name)
        {
            
            return repository.IngredientsExists(name);  
       
        }


        public bool Update(int id,string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {

                return false;
            }
           

            repository.UpdateIngredients(id,name);  
            return true;
        }


        public List<Ingredients> IngredientsList()
        {
            List<Ingredients> ingredients = repository.GetIngredientsList();
            return ingredients;
        }




    }
}
