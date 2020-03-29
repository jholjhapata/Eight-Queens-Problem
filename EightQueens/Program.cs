using System;

namespace EightQueens
{
    class Program
    {

        static bool CheckCondition(bool[,] chess, int x, int y)
        {
            for (int xCount = 0; xCount < 8; xCount++)
            {
                if (chess[xCount, y] && xCount != x)
                    return false;
            }

            for (int yCount = 0; yCount < 8; yCount++)
            {
                if (chess[x, yCount] && yCount != y)
                    return false;
            }

            for (int xCount = x + 1, yCount = y + 1; xCount < 8 && yCount < 8; xCount++, yCount++)
            {
                if (chess[xCount, yCount])
                    return false;
            }

            for (int xCount = x - 1, yCount = y - 1; xCount >= 0 && yCount >= 0; xCount--, yCount--)
            {
                if (chess[xCount, yCount])
                    return false;
            }

            for (int xCount = x - 1, yCount = y + 1; xCount >= 0 && yCount < 8; xCount--, yCount++)
            {
                if (chess[xCount, yCount])
                    return false;
            }

            for (int xCount = x + 1, yCount = y - 1; xCount < 8 && yCount >= 0; xCount++, yCount--)
            {
                if (chess[xCount, yCount])
                    return false;
            }

            return true;
        }


        static bool SetQueen(bool[,] chess, int x, int y)
        {
            
            for (; y < 8; y++)
            {
                chess[x, y] = true;
                //Console.WriteLine("x : " + x.ToString() + " Y : " + y.ToString());
                //printChess(chess);
                if (!CheckCondition(chess, x, y))
                {
                    //Console.WriteLine("Condition False");
                    //Console.ReadLine();
                    chess[x, y] = false;
                }
                else
                {
                   // Console.WriteLine("Condition True");
                    //Console.ReadLine();
                    if (x == 7)
                        return true;
                    if (!SetQueen(chess, x + 1, 0))
                    {
                        //Console.WriteLine("Set False");
                        //Console.ReadLine();
                        chess[x, y] = false;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (y == 8)
                return false;
            else
                return true;
        }

        static void printChess(bool[,] chess)
        {
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    Console.Write(chess[x, y] ? "Q " : "_ ");
                }
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            bool[,] chess = new bool[8, 8];
            for (int x = 0; x < 8; x++)
            {
                for (int y = 0; y < 8; y++)
                {
                    chess[x, y] = false;
                }
            }
            SetQueen(chess, 0, 0);

            printChess(chess);
        }
    }
}
