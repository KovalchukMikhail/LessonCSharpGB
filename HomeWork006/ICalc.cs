using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork006
{
    public interface ICalc
    {
        double Result { get; set; }
        event EventHandler<CalcEventArgs> MyHandler;
        void AddHandler(EventHandler<CalcEventArgs> handler);
        void RemoveHandler(EventHandler<CalcEventArgs> handler);
        void ShowResult(string message);
        void Sum(double number);
        void Sub(double number);
        void Multy(double number);
        void Divide(double number);
        void CancelLast();
    }
}
