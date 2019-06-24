using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution_3.Entities
{
    class Actor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public Actor(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }
    }
}
