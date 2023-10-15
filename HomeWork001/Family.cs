using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork001
{
    public class Family
    {
        private string family;
        private string gap;
        private string descendant;
        private string ancestor;
        public virtual string GetFamily(Person person)
        {
            family = string.Empty;
            gap = new string('_', 3);
            family += $"{person}";
            GetSpouse(person, gap);
            GetParent(person, gap);
            GetChildren(person, gap);
            return family;
        }
        public virtual string GetAllDescendants(Person person)
        {
            descendant = string.Empty;
            gap = new string('_', 3);
            descendant += $"{person.ToString()}\n";
            GetDescendants(person, gap);
            return descendant;
        }
        public virtual string GetAllAncestors(Person person)
        {
            ancestor = string.Empty;
            gap = new string('_', 3);
            ancestor += $"{person.ToString()}\n";
            GetAncestors(person, gap);
            return ancestor;
        }
        protected virtual void GetSpouse(Person person, string gap = "")
        {
            if (person is Man man)
            {
                if (man.Wife != null)
                {
                    family += $"{gap}Жена: {man.Wife.ToString()}";
                }
            }
            else if (person is Woman women)
            {
                if (women.Husband != null)
                {
                    family += $"{gap}Муж: {women.Husband.ToString()}";
                }
            }
        }
        protected virtual void GetParent(Person person, string gap = "")
        {
            family = $"\n{gap}Отец: {person.Mother.ToString()}\n{gap}Мать: {person.Mother.ToString()}\n" + family;
        }
        protected virtual void GetChildren(Person person, string gap = "")
        {
            foreach(Person child in person.Children)
            {
                if(child is Man man)
                {
                    family += $"\n{gap}Сын: {child.ToString()}";
                }
                else if(child is Woman women)
                {
                    family += $"\n{gap}Дочь: {child.ToString()}";
                }
            }
        }
        protected virtual void GetDescendants(Person person, string gap)
        {
            foreach(Person child in person.Children)
            {
                descendant += $"{gap}{child.ToString()}\n";
                GetDescendants(child, gap + "___");
            }
        }
        protected virtual void GetAncestors(Person person, string gap)
        {
            if(person.Mother != null)
            {
                ancestor += $"{gap}{person.Mother.ToString()}\n";
                GetAncestors(person.Mother, gap + "___");
            }
            if (person.Father != null)
            {
                ancestor += $"{gap}{person.Father.ToString()}\n";
                GetAncestors(person.Father, gap + "___");
            }
        }
    }
}
