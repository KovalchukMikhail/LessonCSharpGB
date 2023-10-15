using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lesson02
{
    public static class InsertionSort
    {
        public static void AddOnRightPlace(this List<int> numbers, int nextNum)
        {
            numbers.Add(nextNum);
            int temp = nextNum;
            int i = numbers.Count - 1;
            while (i > 0 && numbers[i - 1] > temp)
            {
                numbers[i] = numbers[i - 1];
                i--;
            }
            numbers[i] = temp;
        }
    }
}
