using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Measure
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Measure() { }

        public Measure(int id, string name) 
        
        { 
            Id = id; 
            Name = name;
        }
        
    }
}
