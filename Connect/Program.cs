using System;
using System.Text;

namespace Connect
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(8, 5);
            game.Start();
        }
    }

    public class Game
    {
        private bool?[,] tiles;
        private int width;
        private int height;
        private bool player;

        public Game(int width, int height)
        {
            this.tiles = new bool?[width, height];
            this.width = width;
            this.height = height;
            this.player = Convert.ToBoolean(new Random().Next(1));
        }

        public void Start()
        {
            StringBuilder sb = new StringBuilder();

            Print(sb);
            string read = Console.ReadLine();

            while(read != ":q")
            {
                bool processed = TryProcessInput(read);

                Print(sb);
                read = Console.ReadLine();

                //  true   ^  true    => false
                //  true   ^  false   => true
                //  false  ^  true    => true
                //  false  ^  false   => false
                this.player = processed ^ player;
            }
        }

        private bool TryProcessInput(string read)
        {
            if(!int.TryParse(read, out int column) || column < 0 || column >= width)
            {
                return false;
            }

            column--;
            int row = height - 1;

            while(tiles[column, row] != null)
            {
                row--;
                if(row < 0) return false;
            }

            tiles[column, row] = player;
            return true;
        }

        private void Print(StringBuilder sb)
        {
            // Clean
            sb.Clear();
            Console.SetCursorPosition(0, 0);

            // Paint table
            for(int i = 0; i < height; i++)
            {
                sb.Append('-', width * 2 + 1);
                sb.AppendLine();

                for(int j = 0; j < width; j++)
                {
                    sb.Append("|");
                    sb.Append(PrintValue(tiles[j, i]));
                }

                sb.AppendLine("|");
            }

            sb.Append('-', width * 2 + 1);

            // Paint end
            Console.WriteLine(sb.ToString());
            Console.Write("Elige linea:     ");
            Console.SetCursorPosition(Console.CursorLeft - 4, Console.CursorTop);
        }

        private static string PrintValue(bool? value) => value.HasValue ? value.Value ? "X" : "O" : " ";
    }
}