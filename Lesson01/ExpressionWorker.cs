using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson01
{
    public class ExpressionWorker
    {
        public string GetResultExpression(string argOne, string argTwo, string action)
        {
            return ExecuteExpression(Convert.ToDouble(argOne), Convert.ToDouble(argTwo), action).ToString();
        }
        public double ExecuteExpression(double argOne, double argTwo, string action) => action switch
        {
            "*" => argOne * argTwo,
            "/" => argOne / argTwo,
            "+" => argOne + argTwo,
            "-" => argOne - argTwo,
            _ => throw new ArgumentException($"Получена некорректная операци для вычесления{action}"),
        };
    }
}
