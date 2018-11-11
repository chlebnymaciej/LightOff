using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightOff
{
    class Program
    {

        static void SetMap(int[,] field)
        {
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    field[i, j] = random.Next(0, 2);
                    if (field[i, j] == 0)
                        field[i, j]--;
                }
            }
        }

        static void Show(int[,] field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field[i, j] == 1)
                        Console.Write(field[i, j]);
                    else
                        Console.Write("0");
                }
                Console.Write("\n");
            }
        }
        static void Change(int[,] field, int x, int y)
        {
            field[x, y] *= -1;
            if (y < 10) field[x, y + 1] *= -1;
            if (x < 10) field[x + 1, y] *= -1;
            if (x > 0) field[x - 1, y] *= -1;
            if (y > 0) field[x, y - 1] *= -1;

        }
        static bool Win(int[,] field)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (field[i, j] == 1)
                        return true;
                }
            }
            return false;
        }
        static void ReverseHistory(int[,] field, int reverse, List<int> xHistory, List<int> yHistory, int count)
        {
            int maks =-1+ xHistory.Count;
            count -= reverse;
            for (int i=0; i<reverse; i++)
            {
                int index = maks - i;
                Change(field, xHistory[index], yHistory[index]);
            }
        }

        static void Main(string[] args)
        {
            int[,] field = new int[10, 10];

            List<int> xHistory = new List<int>();
            List<int> yHistory = new List<int>();
            int Record = 32000;
            int count = 0;
            SetMap(field);
            Show(field);

            int x = 0;
            int y = 0;
            int chan;

            do
            {
                Console.Write("Cofasz ruchy czy gramy dalej? [c/g]");
                
                do
                {
                    Console.WriteLine("--------------------------------");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                    if (x < 10 && y < 10)
                        chan = 1;
                    else
                    {
                        chan = 0;
                        Console.WriteLine("Error zle dane");
                    }
                } while (chan != 1);

                Change(field, x, y);
                count++;

                xHistory.Add(x);
                yHistory.Add(y);

                Show(field);
                
            } while (Win(field));


            Console.Read();


        }
    }
}
