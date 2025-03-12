using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }
   
    
        public Ingredients() 
        { }


        public Ingredients(int id, string name)
        { 
            Id = id;    
            Name = name;    
        }
    
    }

}
