using System.Collections.Immutable;

namespace HomeWork004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { -87, 9, 7, 66, 3, 2, 12, 1, 6, 7, 123, -98, 5, 6, 7, 8, 9, -10, -1, -2, 4, 1005 };

            int purposNumber = 1008;

            int[] result = FindThreeNumbers(numbers, purposNumber);
            if(result == null)
            {
                Console.WriteLine("В массиве нет подходящих чисел");
            }
            else
            {
                Console.WriteLine($"искомые числа {result[0]} + {result[1]} + {result[2]} = {purposNumber}");
            }
        }

        public static int[] FindThreeNumbers(int[] numbers, int purposNumber)
        {
            Array.Sort(numbers);
            int[] result = new int[3];
            int sizeForSearch = numbers.Length - 1;

            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i + 1; j < sizeForSearch; j++)
                {
                    int temp = purposNumber - numbers[i] - numbers[j];
                    int size = numbers.Length - j;
                    int index = Array.BinarySearch(numbers, j, size, temp);
                    if (index >= 0)
                    {
                        result[0] = numbers[i];
                        result[1] = numbers[j];
                        result[2] = temp;
                        return result;
                    }
                }
            }
            return null;
        }

    }
}