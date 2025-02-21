using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDataTemplates
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Location { get; set; }

        public override string ToString()
        {
            return Name + Age;
        }
    }
}
