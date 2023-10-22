using System;

namespace HomeWork002
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte byteNum = 2;
            short shortNum = 4;
            int intNum = 8;
            long longNum = 16;
            Bits bitsOfByte = byteNum;
            Bits bitsOfShort = shortNum;
            Bits bitsOfInteger = intNum;
            Bits bitsOfLong = longNum;
            List<IBits> bits = new List<IBits>()
            {
                 bitsOfByte, bitsOfShort, bitsOfInteger, bitsOfLong
            };
            foreach(IBits num in bits)
            {
                Console.WriteLine($"Число: {num}");
                for (int i = num.MaxBitsCount - 1; i >= 0; i--)
                {
                    Console.Write(num.GetBit(i));
                }
                Console.WriteLine();
            }
            int count = 0;
            foreach (IBits num in bits)
            {
                Console.WriteLine($"Для Числа: {num} убираем {++count} бит и добавляем последний");
                num.SetBit(false, count);
                num.SetBit(true, num.MaxBitsCount - 1);
                for (int i = num.MaxBitsCount - 1; i >= 0; i--)
                {
                    Console.Write(num.GetBit(i));
                }
                Console.WriteLine();
                Console.WriteLine($"Получилось число: {num}");
            }
            

        }
    }
}