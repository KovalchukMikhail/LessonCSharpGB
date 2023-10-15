using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork001
{
    public class Woman : Person
    {
        public Man Husband { get; set; }
        public Woman(string name, DateOnly birthday, Person mother = null, Person father = null) : base(name, birthday, mother, father) { }
    }
}
