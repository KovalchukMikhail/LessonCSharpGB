using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork002
{
    internal class Bits : IBits
    {
        public long Value { get; set; }
        public int MaxBitsCount { get; }
        public long MaxValue { get; }
        
        public Bits(byte number)
        {
            Value = number;
            MaxBitsCount = (int)IntegerEnum.Byte;
            MaxValue = byte.MaxValue;
        }
        public Bits(short number)
        {
            Value = number;
            MaxBitsCount = (int)IntegerEnum.Short;
            MaxValue = short.MaxValue;
        }
        public Bits(int number)
        {
            Value = number;
            MaxBitsCount = (int)IntegerEnum.Integer;
            MaxValue = int.MaxValue;
        }
        public Bits(long number)
        {
            Value = number;
            MaxBitsCount = (int)IntegerEnum.Long;
            MaxValue = long.MaxValue;
        }
        public static implicit operator Bits(byte value) => new Bits(value);
        public static implicit operator Bits(short value) => new Bits(value);
        public static implicit operator Bits(int value) => new Bits(value);
        public static implicit operator Bits(long value) => new Bits(value);
        public bool GetBit(int index)
        {
            if (index < MaxBitsCount || index >= 0)
            {
                return ((Value >> index) & 1) == 1;
            }
            else
            {
                Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                return false;
            }
        }

        public void SetBit(bool bit, int index)
        {
            if (index < MaxBitsCount || index >= 0)
            {
                if (bit == true)
                    Value = (Value | ((long)1 << index));
                else
                {
                    long mask = (long)(1 << index);
                    mask = (long)(MaxValue ^ mask);
                    Value &= (long)(Value & mask);
                }
            }
            else
            {
                Console.WriteLine($"Выход за пределы от 0 до {MaxBitsCount}");
                return;
            }

        }
        public override string ToString()
        {
            return Value.ToString();
        }

    }
}
