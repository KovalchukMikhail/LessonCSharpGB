namespace Lesson02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] a = { { 7, 3, 2 }, { 4, 9, 6 }, { 1, 8, 5 } };
            int sizeOne = a.GetLength(0);
            int sizeTwo = a.GetLength(1);
            List<int> temp = new List<int>();

            Console.WriteLine("Исходный массив:");
            for (int i = 0; i < sizeOne; i++)
            {
                for(int j = 0; j < sizeTwo; j++)
                {
                    temp.AddOnRightPlace(a[i, j]);
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }

            int k = 0;
            Console.WriteLine("Отсортированный массив:");
            for (int i = 0; i < sizeOne; i++)
            {
                for (int j = 0; j < sizeTwo; j++)
                {
                    a[i, j] = temp[k++];
                    Console.Write(a[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}