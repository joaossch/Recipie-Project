using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models; 

namespace Repository
{
    internal class RecipiesRepository
    {

        public string _connectionString;


        public RecipiesRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }

        
        public void Insert(Recipes recipes) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO  Recipies(title, preparationMethod, userId,categoryId,difficultyId) VALUES (@title, @preparationMethod,@userID,categoryId,difficultyId )";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", recipes.Title);
                    command.Parameters.AddWithValue("@email", recipes.PreparationMethod);
                    command.Parameters.AddWithValue("@username", recipes.UserId);
                    command.Parameters.AddWithValue("@password", recipes.CategoryId);
                    command.Parameters.AddWithValue("@isAdmin", recipes.DifficultyId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
            






    }
}
