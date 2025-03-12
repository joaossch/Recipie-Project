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
    public class CategoryService
    {
        public string _connectionString;
        CategoryRepository _repository = new CategoryRepository();

        public CategoryService()
        {
            BaseConfigurations baseConfigurations = new BaseConfigurations();
            _connectionString = baseConfigurations.GetDatabaseConnectionString();
        }

        public bool Insert(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
            {
                return false;
            }

            _repository.Insert(category);
            return true;
        }

        public bool Update(int id, string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }

            _repository.UpdateCategory(id, name);
            return true;
        }

        public List<Category> CategoryList()
        {
            List<Category> category = _repository.GetCategoryList();
            return category;
        }
    }
}
