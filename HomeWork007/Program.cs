using System.Reflection;
using System.Text;
using static HomeWork007.Program;

namespace HomeWork007
{
    public class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(TestClass);

            //var t1 = Activator.CreateInstance(type);
            //var t2 = Activator.CreateInstance(type, new Object[] { 1 });
            //var t3 = Activator.CreateInstance(type, new Object[] { 1, "строка", 2.0, new char[] { 'A', 'B', 'C' } });

            var s = ObjectToString(new TestClass(15, "STR", 2.2m, new char[] { 'A', 'B', 'C' }));
            Console.WriteLine(s);

            var o = StringToObject(s) as TestClass;

            Console.WriteLine("Повторный запуск ObjectToString после запуска StringToObject для проверки");
            s = ObjectToString(o);
            Console.WriteLine(s);

        }
        [AttributeUsage(AttributeTargets.Property)]
        class DontSaveAttribute : Attribute
        { }

        [AttributeUsage(AttributeTargets.Field)]
        public class CustomFieldNameAttribute : Attribute
        {
            public string Name { get; set; }
            public CustomFieldNameAttribute(string name)
            {
                Name = name;
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class CustomPropertyNameAttribute : Attribute
        {
            public string Name { get; set; }
            public CustomPropertyNameAttribute(string name)
            {
                Name = name;
            }
        }
        //static string ObjectToString(object o)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    Type t = o.GetType();
        //    sb.Append(t.AssemblyQualifiedName + ":");
        //    sb.Append(t.Name + "|");
        //    var properties = t.GetProperties();


        //    foreach (var p in properties)
        //    {
        //        Console.WriteLine(p);

        //        if (p.GetCustomAttribute<DontSaveAttribute>() != null)
        //        {
        //            continue;
        //        }

        //        var value = p.GetValue(o);

        //        sb.Append(p.Name + ":");
        //        if (p.PropertyType == typeof(char[]))
        //        {
        //            sb.Append(new String(value as char[]) + "|");
        //        }
        //        else
        //            sb.Append(value + "|");

        //    }

        //    return sb.ToString();

        //}


        static string ObjectToString(object o)
        {
            StringBuilder sb = new StringBuilder();
            Type t = o.GetType();
            sb.Append(t.AssemblyQualifiedName + ":");
            sb.Append(t.Namespace + "." + t.Name + "|");
            var properties = t.GetProperties(BindingFlags.NonPublic | BindingFlags.Instance);
            var properties2 = t.GetProperties();

            //foreach (var p in properties)
            //{
            //    //Console.WriteLine(p);
            //    var value = p.GetValue(o);

            //    sb.Append(p.Name + ":");
            //    if (p.PropertyType == typeof(char[]))
            //    {
            //        sb.Append(new String(value as char[]) + "|");
            //    }
            //    else
            //        sb.Append(value + "|");

            //}
            var fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            foreach(var field in fields)
            {
                var attr = field.GetCustomAttribute<CustomFieldNameAttribute>();
                if (attr != null)
                {
                    sb.Append($"field:{attr.Name}:{field.GetValue(o)}|");
                }
            }

            return sb.ToString();

        }
        static object StringToObject(string s)
        {
            var values = s.Split("|");

            var classAssemblyAndName = values[0].Split(':');
            var obj = Activator.CreateInstance(null, classAssemblyAndName[1])?.Unwrap();
            var type = obj.GetType();

            if (values.Length > 1 && obj != null)
            {
                var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                var properties = type.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                for (int i = 1; i < values.Length; i++)
                {
                    string[] nameAndValue = values[i].Split(":");
                    if (nameAndValue[0] == "field")
                    {
                        foreach (var property in properties)
                        {
                            var propertyAttr = property?.GetCustomAttribute<CustomPropertyNameAttribute>();
                            if(propertyAttr != null && nameAndValue[1] == propertyAttr.Name)
                            {
                                SetPropertyValue(property, obj, nameAndValue[2]);
                                break;
                            }
                        }
                    }
                    //var nameAndValue = values[i].Split(":");
                    //var pi = type.GetProperty(nameAndValue[0]);

                    //Console.WriteLine($"{nameAndValue[0]}:{pi}");

                    //if (pi == null)
                    //    continue;

                    //if (pi.PropertyType == typeof(int))
                    //{
                    //    pi.SetValue(obj, int.Parse(nameAndValue[1]));
                    //}
                    //if (pi.PropertyType == typeof(string))
                    //{
                    //    pi.SetValue(obj, nameAndValue[1]);
                    //}
                    //if (pi.PropertyType == typeof(decimal))
                    //{
                    //    pi.SetValue(obj, decimal.Parse(nameAndValue[1]));
                    //}
                    //if (pi.PropertyType == typeof(char[]))
                    //{
                    //    pi.SetValue(obj, nameAndValue[1].ToCharArray());
                    //}

                }
            }
            return obj;
        }
        static void SetPropertyValue(PropertyInfo property, object obj, string value)
        {
            if (property.PropertyType == typeof(int))
            {
                property.SetValue(obj, int.Parse(value));
            }
            if (property.PropertyType == typeof(string))
            {
                property.SetValue(obj, value);
            }
            if (property.PropertyType == typeof(decimal))
            {
                property.SetValue(obj, decimal.Parse(value));
            }
            if (property.PropertyType == typeof(char[]))
            {
                property.SetValue(obj, value.ToCharArray());
            }
        }

    }
    public class TestClass
    {
        [CustomFieldNameAttribute("Целочисленное")]
        private int i;
        [CustomFieldNameAttribute("Строка")]
        private string s;
        [CustomFieldNameAttribute("Вещественное")]
        private decimal d;
        [CustomPropertyNameAttribute("Целочисленное")]
        public int I
        {
            get { return i; }
            set { i = value; }
        }
        [CustomPropertyNameAttribute("Строка")]
        private string? S
        {
            get { return s;}
            set { s = value; }
        }
        [CustomPropertyNameAttribute("Вещественное")]
        public decimal D
        {
            get { return d; }
            set { d = value; }
        }

        public char[]? C { get; set; }

        public TestClass()
        { }
        public TestClass(int i)
        {
            this.I = i;
        }
        public TestClass(int i, string s, decimal d, char[] c) : this(i)
        {
            this.S = s;
            this.D = d;
            this.C = c;
        }
    }
}