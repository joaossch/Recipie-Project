using Models;
using System.Data;
using System.Data.SqlClient;


namespace Repository
{
    public class UserRepository
    {
        public string _connectionString;


        public UserRepository()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }






        public void UpdateUser(int id, string name ,string email )
        {
            
            string query = "UPDATE [Users] SET name = @name, , email = @email WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;  
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;  
                   
                  
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;  

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();  

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Usuário atualizado com sucesso.");
                    }
                    else
                    {
                        Console.WriteLine("Nenhum usuário foi atualizado. Verifique o ID fornecido.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                
                Console.WriteLine($"Erro ao executar o SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }
        }

        public bool UpdateUserPassword(int id, string newPassword)
        {
            
            string query = "UPDATE [Users] SET password = @password WHERE id = @id";

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    
                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                    cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = newPassword;

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery(); 

                    return rowsAffected > 0; 
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine($"Erro ao executar o SQL: {sqlEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro inesperado: {ex.Message}");
            }

            return false; 
        }

        public void Insert(User user)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Users(name, email, username, password,isAdmin) VALUES (@name, @email, @username, @password,@isAdmin)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("name", user.Name);
                    command.Parameters.AddWithValue("@email", user.Email);
                    command.Parameters.AddWithValue("@username", user.Username);
                    command.Parameters.AddWithValue("@password", user.Password);
                    command.Parameters.AddWithValue("@isAdmin", user.IsAdmin);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }



        public bool SelectLogin(string username, string password)
        {
            
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            string query = "SELECT password FROM [Users] WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                var result = cmd.ExecuteScalar();

                
                if (result == null)
                {
                    return false;
                }

                string storedPassword = result.ToString();

                
                return storedPassword == password;
            }
        }

        public int GetUserId(string username, string password)
        {
            
            string query = "SELECT id FROM [Users] WHERE username = @username AND password = @password";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                conn.Open();
                var result = cmd.ExecuteScalar(); 

                
                return result != null ? Convert.ToInt32(result) : 0;
            }
        }

        public bool UsernameExists(string username)
        {
            
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            string query = "SELECT COUNT(*) FROM [Users] WHERE username = @username";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);

                conn.Open();
                int count = (int)cmd.ExecuteScalar();

                return count > 0; 
            }
        }

        public bool IsUserAdmin(int userId)
        {
            string query = "SELECT isAdmin FROM [Users] WHERE id = @id";  

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = userId;  

                conn.Open();

                var result = cmd.ExecuteScalar();

                if (result == DBNull.Value)
                {
                    return false;
                }

                return Convert.ToInt32(result) == 1;
            }
        }





    }
}