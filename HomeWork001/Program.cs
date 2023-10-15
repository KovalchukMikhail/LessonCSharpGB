namespace HomeWork001
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Man jack = new Man("Jack", new DateOnly(1930, 1, 6));
            Woman olga = new Woman("Olga", new DateOnly(1927, 1, 6));
            jack.Wife = olga;
            olga.Husband = jack;

            Man jim = new Man("Jim", new DateOnly(1928, 1, 6));
            Woman sveta = new Woman("Sveta", new DateOnly(1926, 1, 6));
            jim.Wife = sveta;
            sveta.Husband = jim;

            Man stiv = new Man("Stiv", new DateOnly(1960, 1, 6), olga, jack);
            Woman ann = new Woman("Ann", new DateOnly(1959, 1, 6), sveta, jim);
            stiv.Wife = ann;
            ann.Husband = stiv;

            Man tom = new Man("Tom", new DateOnly(1987, 1, 6), ann, stiv);
            Woman clara = new Woman("Clara", new DateOnly(1988, 1, 6));

            tom.Wife = clara;
            clara.Husband = tom;

            Man sun1 = new Man("sun1", new DateOnly(2010, 1, 6), clara, tom);
            Man sun2 = new Man("sun2", new DateOnly(2011, 1, 6), clara, tom);
            Man sun3 = new Man("sun3", new DateOnly(2012, 1, 6), clara, tom);

            Woman daughter1 = new Woman("daughter1", new DateOnly(2009, 1, 6), clara, tom);
            Woman daughter2 = new Woman("daughter2", new DateOnly(2013, 1, 6), clara, tom);
            Woman daughter3 = new Woman("daughter3", new DateOnly(2014, 1, 6), clara, tom);

            Family family = new Family();

            while(true)
            {
                Console.WriteLine("Введите:\n" +
                "1 - Посмотреть семью Тома\n" +
                "2 - Всех потомков Джека\n" +
                "3 - Всех предков sun1\n" +
                "0 - для выхода\n");

                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "1": Console.WriteLine(family.GetFamily(tom)); break;
                    case "2": Console.WriteLine(family.GetAllDescendants(jack)); break;
                    case "3": Console.WriteLine(family.GetAllAncestors(sun1)); break;
                    case "0": return;
                    default: Console.WriteLine("Введина неизвестная команда"); break;
                }
            }
        }
    }
}