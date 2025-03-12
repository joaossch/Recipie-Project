using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Recipes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PreparationMethod { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }
        public int DifficultyId { get; set; }



        public  Recipes()
        {

        }

        public Recipes(int id, string title, string preparationMethod, int userid, int categoryId, int difficultyId )
        {
            Id = id;
            Title = title;
            PreparationMethod = preparationMethod;
            UserId = userid;
            CategoryId = categoryId;
            DifficultyId = difficultyId;  
          


        }

    }
}
