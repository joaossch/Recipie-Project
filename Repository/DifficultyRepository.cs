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
    public class DifficultyRepository
    {
        public string _connectionString;
        
        public List<Difficulty> _difficultyList;
        
            BaseConfigurations baseConfigurations = new BaseConfigurations();

            public DifficultyRepository()
            {
                BaseConfigurations baseConfigurations = new BaseConfigurations();
                _connectionString = baseConfigurations.GetDatabaseConnectionString();

            }

        public void Insert(Difficulty difficulty)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO  Difficulty (name) VALUES (@name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", difficulty.Name);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateDifficulty(int id, string name)
        {
            string query = "UPDATE [Difficulty] SET name = @name WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    return rowsAffected > 0;  // Retorna true se algum registro foi atualizado
                }
            }
            catch (SqlException sqlEx)
            {
                throw new Exception($"Error in SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }



        public List<Difficulty> GetDifficultyList()
        {
            List<Difficulty> difficulty = new List<Difficulty>();
            string query = "SELECT id, name FROM [Difficulty]";

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
                            difficulty.Add(new Difficulty
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

            return difficulty;
        }


    }
}
