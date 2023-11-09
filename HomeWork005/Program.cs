namespace HomeWork005
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ICalc calc = new Calc();
            calc.AddHandler((x, y) => Console.WriteLine($"{(CalcEventArgs)y} Результат операции равен:\n{((ICalc)x).Result}"));

            while (true)
            {
                Console.WriteLine("Введите номер пункта операции\n" +
                    "1 Сложение\n" +
                    "2 Вычитание\n" +
                    "3 Умножение\n" +
                    "4 Деление\n" +
                    "5 Отмена предыдущего дейсвтия\n" +
                    "0 Выход\n");

                string answer = Console.ReadLine();
                double number;
                switch (answer)
                {
                    case "1":
                        if (GetNumber(out number))
                            calc.Sum(number);
                        break;
                    case "2":
                        if (GetNumber(out number))
                            calc.Sub(number);
                        break;
                    case "3":
                        if (GetNumber(out number))
                            calc.Multy(number);
                        break;
                    case "4":
                        if (GetNumber(out number))
                            calc.Divide(number);
                        break;
                    case "5":
                        calc.CancelLast();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Введено некоректное значение");
                        break;
                }
            }
        }

        static bool GetNumber(out double result)
        {
            result = double.NaN;
            while (true)
            {
                Console.WriteLine("Введите число или n для возврата в меню выбора операций");
                string answer = Console.ReadLine();
                if (answer == "n")
                    return false;

                try
                {
                    result = Convert.ToDouble(answer);
                    return true;
                }
                catch
                {
                    Console.WriteLine("Введено не корректное значение.\n");
                }
            }


        }
    }
}