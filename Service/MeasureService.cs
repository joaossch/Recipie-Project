using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Service
{
    public class MeasureService
    {
        public string _connectionString;
        MeasureRepository _repository = new MeasureRepository();


        public MeasureService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }


        public bool Insert(Measure measure)
        {


            if (string.IsNullOrWhiteSpace(measure.Name))
            {

                return false;
            }
            //bool duplicate = repository.IngredientsExists(ingredients.Name);

            //if (duplicate)
            //{
            //    return false;
            //}

            _repository.Insert(measure);


            return true;
        }


        public bool Update(int id, string name)
        {

            if (string.IsNullOrWhiteSpace(name))
            {

                return false;
            }
            

            _repository.UpdateMeasure(id, name);
            return true;
        }



        public List<Measure> MeasureList()
        { 
            List<Measure> measure = _repository.GetMeasureList();
            return measure;
        }


    }
}
