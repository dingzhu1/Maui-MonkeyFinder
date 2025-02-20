using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDataBinding.Models
{
    public class Person
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Fullname => $"{Forename} {Surname}";
    }
}
