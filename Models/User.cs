using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
         
        public string Password { get; set; }


        public bool IsAdmin { get; set; }
       

        public User() { }




        public User(int id, string name, string email, string username, string password, bool isAdmin)
        {
         Id = id;
         Name = name;    
         Email = email;  
         Username = username;
         Password = password;
         IsAdmin = isAdmin;               

        
        
        
        }




    }

}

