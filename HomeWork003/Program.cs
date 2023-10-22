using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace HomeWork003
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] labirynth1 = new int[,]
            {
                {1, 1, 1, 1, 1, 1, 1 },
                {1, 0, 0, 0, 0, 0, 1 },
                {1, 0, 1, 1, 1, 0, 1 },
                {0, 0, 0, 0, 1, 0, 0 },
                {1, 1, 0, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 },
                {1, 1, 1, 0, 1, 1, 1 }
            };
            int startI = 3;
            int startJ = 2;
            int result = HasExit(startI, startJ, labirynth1);
            Console.WriteLine($"Если стартовать с точки с координатами i = {startI}, j = {startJ} то лабиринт имеет: {result} выходов");
        }

        static int HasExit(int startI, int startJ, int[,] l)
        {
            int result = 0;
            if (l[startI, startJ] == 1)
                return result;
            int lastI = l.GetLength(0) - 1;
            int lastJ = l.GetLength(1) - 1;
            int[,] labyrinth = (int[,])l.Clone();
            if (startI == 0 || startI == lastI || startJ == 0 || startJ == lastJ)
            {
                result++;
                labyrinth[startI, startJ] = 3;
            }
            Queue<int[]> way = new Queue<int[]>();
            way.Enqueue(new int[2] { startI, startJ });
            while(way.TryDequeue(out int[] temp))
            {
                if(TryMoveLeft(temp, way, labyrinth) == 3) result++;
                if(TryMoveUp(temp, way, labyrinth) == 3) result++;
                if(TryMoveRight(temp, way, labyrinth, lastJ) == 3) result++;
                if(TryMoveDown(temp, way, labyrinth, lastI) == 3) result++;
            }
            if (result > 0) Console.WriteLine("Путь отмечен цифрой 2, выходы отмечены циврой 3");
            for(int i = 0; i < labyrinth.GetLength(0); i++)
            {
                for(int j = 0; j < labyrinth.GetLength(1); j++)
                {
                    Console.Write(labyrinth[i, j] + " ");
                }
                Console.WriteLine();
            }
            return result;
        }
        public static int TryMoveLeft(int[] currentPoint, Queue<int[]> queue, int[,] labyrinth)
        {
            if (currentPoint[1] != 0)
            {
                int nextJ = currentPoint[1] - 1;
                if (labyrinth[currentPoint[0], nextJ] == 0)
                {
                    queue.Enqueue(new int[] { currentPoint[0], nextJ });
                    if(nextJ == 0)
                    {  
                        return labyrinth[currentPoint[0], nextJ] = 3;
                    }
                    return labyrinth[currentPoint[0], nextJ] = 2;
                }
                return 1;
            }
            return -1;
        }
        public static int TryMoveUp(int[] currentPoint, Queue<int[]> queue, int[,] labyrinth)
        {
            if (currentPoint[0] != 0)
            {
                int nextI = currentPoint[0] - 1;
                if (labyrinth[nextI, currentPoint[1]] == 0)
                {
                    queue.Enqueue(new int[] { nextI, currentPoint[1]});
                    if (nextI == 0)
                    {
                        return labyrinth[nextI, currentPoint[1]] = 3;
                    }
                    return labyrinth[nextI, currentPoint[1]] = 2;
                }
                return 1;
            }
            return -1;
        }
        public static int TryMoveRight(int[] currentPoint, Queue<int[]> queue, int[,] labyrinth, int lastJ)
        {
            if (currentPoint[1] != lastJ)
            {
                int nextJ = currentPoint[1] + 1;
                if (labyrinth[currentPoint[0], nextJ] == 0)
                {
                    queue.Enqueue(new int[] { currentPoint[0], nextJ });
                    if (nextJ == lastJ)
                    {
                        return labyrinth[currentPoint[0], nextJ] = 3;
                    }
                    return labyrinth[currentPoint[0], nextJ] = 2;
                }
                return 1;
            }
            return -1;
        }
        public static int TryMoveDown(int[] currentPoint, Queue<int[]> queue, int[,] labyrinth, int lastI)
        {
            if (currentPoint[0] != lastI)
            {
                int nextI = currentPoint[0] + 1;
                if (labyrinth[nextI, currentPoint[1]] == 0)
                {
                    queue.Enqueue(new int[] { nextI, currentPoint[1] });
                    if (nextI == lastI)
                    {
                        return labyrinth[nextI, currentPoint[1]] = 3;
                    }
                    return labyrinth[nextI, currentPoint[1]] = 2;
                }
                return 1;
            }
            return -1;
        }

    }
}