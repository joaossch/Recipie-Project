﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Difficulty
    {
        public int Id { get; set; }    
        public string Name { get; set; }

       public Difficulty() { }


        public Difficulty(int id, string name)
        { 
        Id = id;    
        Name = name;
         
        }    


    }
}
