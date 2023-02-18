namespace Virtual_Methods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NonPlayerCharacter[] players =
            {
                new NonPlayerCharacter(),
                new Farmer(),
                new Knight(),
                new Child()
            };

            foreach (var player in players)
            {
                player.ShowInfo();
                Console.WriteLine(new String('-', 35));
            }
        }
    }

    class NonPlayerCharacter
    {
        public virtual void ShowInfo()
        {
            Console.WriteLine("Я простой НПС, я просто хожу");
        }
    }

    class Farmer : NonPlayerCharacter
    {
        public override void ShowInfo()
        {
            base.ShowInfo();
            Console.WriteLine("А ещё я умею работать в поле");
        }
    }
    
    class Knight : NonPlayerCharacter
    {
        public override void ShowInfo()
        {
            Console.WriteLine("Я рыцарь, моё дело - это сражения!");
        }
    }

    class Child : NonPlayerCharacter
    {

    }

}