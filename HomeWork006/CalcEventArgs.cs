using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork006
{
    public class CalcEventArgs
    {
        public string OperationName { get; set; } = string.Empty;
        public CalcEventArgs(string operationName)
        {
            OperationName = operationName;
        }
        public override string ToString()
        {
            return OperationName;
        }
    }
}
