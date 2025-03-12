using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;


namespace Service
{
    public class DifficultyService
    {
        public string _connectionString;
        DifficultyRepository _repository = new DifficultyRepository();  

        

        public DifficultyService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();

        }

        public bool Insert(Difficulty difficulty)
        {


            if (string.IsNullOrWhiteSpace(difficulty.Name))
            {

                return false;
            }
           

            _repository.Insert(difficulty);

           
            return true;
        }


        public bool Update(int id, string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {

                return false;
            }
           

            _repository.UpdateDifficulty(id, name);
            return true;
        }



        public List<Difficulty> DifficultyList()
        {
            List<Difficulty> difficulty = _repository.GetDifficultyList();
            return difficulty;
        }


    }
}
