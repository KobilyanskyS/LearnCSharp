namespace PacMan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible= false;

            char[,] map = ReadMap("map.txt");
            ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

            Task.Run(() =>
            {
                while (true)
                {
                    pressedKey = Console.ReadKey();
                }
            });

            int pacmanX = 19;
            int pacmanY = 7;
            int score = 0;

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();

                HandleInput(pressedKey, ref pacmanX, ref pacmanY, map, ref score);

                Console.ForegroundColor= ConsoleColor.Blue;
                DrawMap(map);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(pacmanX, pacmanY);
                Console.Write("@");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(42, 0);
                Console.Write($"Score: {score}");

                Thread.Sleep(125);

                if (score >= 369)
                {
                    isRunning = false;
                }

            }

            if (score >= 369)
            {
                char[,] win = ReadMap("win.txt");
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                DrawMap(win);
                Console.ReadKey();
            }
            
        }

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines(path);

            char[,] map = new char[GetMaxLengthOfLine(file), file.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }

            return map;

        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x,y]);
                }
                Console.Write("\n");
            }
        }

        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY, char[,] map, ref int score ) 
        { 
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = pacmanX + direction[0];
            int nextPacmanPositionY = pacmanY + direction[1];

            char nextCell = map[nextPacmanPositionX, nextPacmanPositionY];

            if (nextCell == ' ' || nextCell == '.')
            {
                pacmanX = nextPacmanPositionX;
                pacmanY = nextPacmanPositionY;

                if (nextCell == '.')
                {
                    score++;
                    map[nextPacmanPositionX, nextPacmanPositionY] = ' ';
                }
            }
        }

        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        { 
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow || pressedKey.Key == ConsoleKey.W)
            {
                direction[1] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow || pressedKey.Key == ConsoleKey.S)
            {
                direction[1] = 1;
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow || pressedKey.Key == ConsoleKey.A)
            {
                direction[0] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow || pressedKey.Key == ConsoleKey.D)
            {
                direction[0] = 1;
            }

            return direction;

        }
            

         

        private static int GetMaxLengthOfLine(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach(var line in lines)
            {
                if(line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }
            return maxLength;

        }
    }
}