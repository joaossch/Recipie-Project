using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Repository
{
    public class IngredientsRepository
    {
        public string _connectionString;

        public List<Ingredients> Ingredients { get; set; } = new List<Ingredients>();
        public IngredientsRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }

        public void Insert(Ingredients ingridents)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO  Ingredients (name) VALUES (@name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", ingridents.Name);
                    

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool IngredientsExists(string name)
        {
            
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }

            string query = "SELECT COUNT(*) FROM [Ingredients] WHERE name = @name";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", name);

                conn.Open();
                int count = (int)cmd.ExecuteScalar(); 

                return count > 0; 
            }
        }


        public bool UpdateIngredients(int id, string name)
        {
            string query = "UPDATE [Ingredients] SET name = @name WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;  
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Erro ao executar o SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }
        }


        public List<Ingredients> GetIngredientsList()
        {
            List<Ingredients> ingredients = new List<Ingredients>();
            string query = "SELECT id, name FROM [Ingredients]";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ingredients.Add(new Ingredients
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Erro ao executar o SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro inesperado: {ex.Message}");
            }

            return ingredients;
        }




    }
}
