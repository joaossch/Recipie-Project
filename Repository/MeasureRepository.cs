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
    public class MeasureRepository
    {
        public string _connectionString;
        public List<Measure> measure { get; set; } = new List <Measure>();
        public MeasureRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }
        public void Insert(Measure measure)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO  Measure (name) VALUES (@name)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", measure.Name);


                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool UpdateMeasure(int id, string name)
        {
            string query = "UPDATE [Measure] SET name = @name WHERE id = @id";

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


        public List<Measure> GetMeasureList()
        {
            List<Measure> measure = new List<Measure>();
            string query = "SELECT id, name FROM [Measure]";

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
                            measure.Add(new Measure
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

            return measure;
        }

    }
}
