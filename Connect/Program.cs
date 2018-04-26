using System;
using System.Text;

namespace Connect
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool?[,] tiles = new bool?[5, 8];

            tiles[0, 3] = true;
            tiles[0, 4] = false;

            int xLength = tiles.GetLength(0);
            int yLength = tiles.GetLength(1);
            string read = null;
            StringBuilder sb = new StringBuilder();

            while(read != ":q")
            {
                sb.Clear();
                Console.SetCursorPosition(0, 0);
                for(int i = 0; i < xLength; i++)
                {
                    sb.Append('-', xLength * 3 + 2);
                    sb.AppendLine();

                    for(int j = 0; j < yLength; j++)
                    {
                        sb.Append("|");
                        sb.Append(PrintValue(tiles[i, j]));
                    }

                    sb.AppendLine("|");
                }

                sb.Append('-', xLength * 3 + 2);

                Console.WriteLine(sb.ToString());

                Console.Write("Elige linea: ");
                read = Console.ReadLine();

                int column = int.Parse(read) - 1;

                tiles[0, column] = true;
            }
        }

        private static string PrintValue(bool? value)
        {
            return value.HasValue ? value.Value ? "X" : "O" : " ";
        }
    }
}
