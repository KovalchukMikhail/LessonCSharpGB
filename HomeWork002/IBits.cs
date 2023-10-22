using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork002
{
    internal interface IBits
    {
        long Value { get; set; }
        int MaxBitsCount { get; }
        long MaxValue { get; }
        bool GetBit(int index);
        void SetBit(bool bit, int index);
    }
}
