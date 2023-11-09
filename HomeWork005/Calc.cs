using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork005
{
    public class Calc : ICalc
    {
        public double Result { get; set; }

        public event EventHandler<CalcEventArgs> MyHandler;
        Stack<double> Results;
        public Calc()
        {
            Result = 0;
            Results = new Stack<double>();
            Results.Push(Result);
        }
        public void AddHandler(EventHandler<CalcEventArgs> handler)
        {
            MyHandler += handler;
        }
        public void RemoveHandler(EventHandler<CalcEventArgs> handler)
        {
            MyHandler -= handler;
        }
        protected void ShowResult(string message)
        {
            MyHandler?.Invoke(this, new CalcEventArgs(message));
        }
        public void Divide(double number)
        {
            Result /= number;
            ShowResult("Выполнена операция деления.");
            Results.Push(Result);
        }

        public void Multy(double number)
        {
            Result *= number;
            ShowResult("Выполнена операция умножения.");
            Results.Push(Result);
        }

        public void Sub(double number)
        {
            Result -= number;
            ShowResult("Выполнена операция вычитания.");
            Results.Push(Result);
        }

        public void Sum(double number)
        {
            Result += number;
            ShowResult("Выполнена операция сложения.");
            Results.Push(Result);
        }

        public void CancelLast()
        {
            if(Results.TryPop(out double temp))
            {
                if (Results.TryPeek(out temp))
                {
                    Result = temp;
                    ShowResult("Выполнена операция отмены последней операции.");
                }
                else
                {
                    ShowResult("Отсутсвуют действия для удаления");
                }
            }
            else
            {
                ShowResult("Отсутсвуют действия для удаления");
            }
        }
    }
}
