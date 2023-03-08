namespace Enum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Game> games = new List<Game>();

            games.Add(new Game("Black and White", Genre.Strategy));
            games.Add(new Game("The Witcher 3: Wild Hunt", Genre.RPG));
            games.Add(new Game("Sid Mister's Civilization VI", Genre.Strategy));
            games.Add(new Game("Ori and Will of the Wisps", Genre.Action));

            foreach (var game in games) 
            {
                game.ShowInfo();
            }
        }
    }

    enum Genre
    {
        Strategy,
        RPG,
        Action
    }

    class Game
    {
        private string _name;
        private Genre _genre;

        public Game(string name, Genre genre)
        {
            _name = name;
            _genre = genre;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Это игра: {_name}, её жанр: {_genre}");
        }
    }
}