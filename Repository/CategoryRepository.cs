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
    public class CategoryRepository
    {
        public string _connectionString;

        public List<Category> _categoryList;

        BaseConfigurations baseConfigurations = new BaseConfigurations();

        public CategoryRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }

        public void Insert(Category category)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO  Category (name) VALUES (@name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", category.Name);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateCategory(int id, string name)
        {
            string query = "UPDATE [Category] SET name = @name WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // Adicionando os parâmetros para evitar SQL Injection
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;  // Retorna true se algum registro foi atualizado
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

        public List<Category> GetCategoryList()
        {
            List<Category> category = new List<Category>();
            string query = "SELECT id, name FROM [Category]";

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
                            category.Add(new Category
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
                throw new Exception($"Error on SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }

            return category;
        }
    }
}
