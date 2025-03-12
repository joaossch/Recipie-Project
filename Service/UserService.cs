using Models;
using Repository;
using System.Data.SqlClient;
using System.Runtime;

namespace Service
{
    public class UserService
    {

        public string _connectionString;



        public UserRepository userRepository = new UserRepository();



        public UserService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }
        
        public bool Insert(User user)

        {
            UserRepository repository = new UserRepository();
            if (string.IsNullOrWhiteSpace(user.Name))
            {

                return false;
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {

                return false;
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {

                return false;
            }

            bool usenameDuplicate = repository.UsernameExists(user.Username);

            if (usenameDuplicate)
            {
                return false;                
            }


            if (string.IsNullOrWhiteSpace(user.Password))
            {

                return false;
            }

            
         
           repository.Insert(user);

            return true;

  
            

        }


        public bool Login(string username, string password)

        {
             UserRepository repository = new UserRepository();
            return repository.SelectLogin(username, password);
                
        }






        public int UserId(string username, string password) 
        {

             UserRepository repository = new UserRepository();  
            int result = repository.GetUserId(username, password);
            return result;
            
           
        } 
         
        public (string name, string email, string username) GetUserInfoById(int userId)
        {
            string query = "SELECT name, email, username FROM Users WHERE id = @id";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", userId);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader["name"].ToString();
                    string email = reader["email"].ToString();
                    string username = reader["username"].ToString();

                    return (name, email, username); 
                }

                return (null, null, null); 
            }
        }




        public bool Update(int id, string name, string email)
        { 
          UserRepository userRepository = new UserRepository();
            UserRepository repository = new UserRepository();
           
            if (string.IsNullOrWhiteSpace(name))
            {

                return false;
            }
           

            if (string.IsNullOrWhiteSpace(email))
            {

                return false;
            }

            


            repository.UpdateUser(id,name,email);

        return true;    
        }


        public bool CheckUsername(string username)
        {
            UserRepository repository = new UserRepository();

           
            return repository.UsernameExists(username);  
        }




        public bool UpdatePassword(int id, string password)
        {  UserRepository repository = new UserRepository();
        
           repository.UpdateUserPassword(id,password); 
            return true;

        
        }

        public bool IsAdmin(int id)
        {
            UserRepository repository = new UserRepository();
            bool isAdmin = repository.IsUserAdmin(id); 
            return isAdmin;  
        }





      
        











    }

}

