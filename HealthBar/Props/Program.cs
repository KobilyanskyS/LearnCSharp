namespace Props
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Renderer renderer = new Renderer();

            Player player = new Player(10, 10);

            renderer.Draw(player.X, player.Y);
        }
    }

    class Renderer
    {
        public void Draw(int x, int y, char character = '@') 
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.WriteLine(character);
            Console.ReadKey(true);
        }
    }

    class Player
    {

        private int _x;
        private int _y;

        public int X { get; private set; }

        public int Y { get; private set; }

        public Player(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
}