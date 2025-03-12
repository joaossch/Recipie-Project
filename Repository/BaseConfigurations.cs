using System;
using System.Data.SqlClient;


namespace Repository




{
    public class BaseConfigurations
    {

        public string _connectionString { get; set; }


        public BaseConfigurations()
        {
          


        }


        public string GetDatabaseConnectionString()
        {
            _connectionString = "Data Source=João\\SQLEXPRESS;Initial Catalog=Project Drink;Integrated Security=true";
            
            return _connectionString;

        }















    }


}
