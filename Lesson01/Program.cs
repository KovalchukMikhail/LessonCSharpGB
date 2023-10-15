using System;

namespace Lesson01
{
    //Написать программу-калькулятор, вычисляющую выражения вида a + b, a - b, a / b, a* b, введенные из командной строки, и выводящую результат выполнения на экран.
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length == 0)
                {
                    Console.WriteLine("Не были переданны параметры");
                    return;
                }
                ExpressionWorker executer = new ExpressionWorker();
                List<string> expression = args.ToList();
                if (expression[0] == "-")
                {
                    expression.RemoveAt(0);
                    expression[0] = "-" + expression[0];
                }
                while (expression.Count > 2)
                {
                    for(int i = 1; i < expression.Count - 1; i++)
                    {
                        if (expression[i] == "*" || expression[i] == "/")
                        {
                            expression[i - 1] = executer.GetResultExpression(expression[i - 1], expression[i + 1], expression[i]);
                            expression.RemoveRange(i, 2);
                            break;
                        }
                    }
                    for(int i = 1; i < expression.Count - 1; i++)
                    {
                        if (expression[i] == "-" || expression[i] == "+")
                        {
                            expression[i - 1] = executer.GetResultExpression(expression[i - 1], expression[i + 1], expression[i]);
                            expression.RemoveRange(i, 2);
                            i = i - 1;
                        }
                    }
                }
                Console.WriteLine($"Результат выражения: {Convert.ToDouble(expression[0])}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Переданно некоректное вырожение. Получно исключение: {ex}");
            }
        }

    }
}