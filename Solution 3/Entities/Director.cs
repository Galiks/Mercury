using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_3.Entities
{
    public class Director
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Director(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"#{Id} Name: {Name}";
        }
    }
}
