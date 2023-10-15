using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork001
{
    public abstract class Person
    {
        public string Name { get; set; }
        public DateOnly Birthday { get; }
        private Person mother;
        private Person father;
        public List<Person> Children { get; }
        public Person(string name, DateOnly birthday, Person mother, Person father)
        {
            Name = name;
            Birthday = birthday;
            if(mother != null)
            {
                this.mother = mother;
                mother.AddChild(this);
            }
            if(father != null)
            {
                this.father = father;
                father.AddChild(this);
            }
            Children = new List<Person>();
        }
        protected void AddChild(Person child)
        {
            Children.Add(child);
        }
        public Person Mother
        {
            get { return mother; }
            set
            {
                if (mother == null)
                {
                    mother = value;
                    mother.AddChild(this);
                }
            }
        }
        public Person Father
        {
            get { return father; }
            set
            {
                if (father == null)
                {
                    father = value;
                    father.AddChild(this);
                }
            }
        }

        public override string ToString()
        {
            return $"Имя: {Name}, Дата рождения: {Birthday.ToShortDateString()}";
        }
    }
}
