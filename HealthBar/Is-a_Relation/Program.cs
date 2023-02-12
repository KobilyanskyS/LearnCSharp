namespace Is_a_Relation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Knight warior1 = new Knight(100, 15, 20);
            Barbarian warior2 = new Barbarian(125, 7, 20, 0.3);
            int hits = 1;
           
            Console.WriteLine("Да начнётся бой!\n");
            Console.Write("Рыцарь\n");
            warior1.ShowInfo();
            Console.WriteLine();
            Console.Write("Варвар\n");
            warior2.ShowInfo();
            Console.WriteLine();

            while (warior2.Health > 0 && warior1.Health > 0)
            {
                Console.WriteLine($"Раунд {hits}");
                if (hits % 2 == 0 ) {
                    Console.WriteLine();
                    warior1.Pray();
                    warior2.Shout();
                }
                Console.WriteLine();
                Console.WriteLine($"{warior1.Name} наносит удар: {warior1.Damage} урона");
                warior2.TakeDamage(warior1.Damage);
                Console.WriteLine($"{warior2.Name} наносит удар: {warior2.Damage} урона");
                warior1.TakeDamage(warior2.Damage);
                Console.WriteLine();
                Console.Write("Рыцарь\n");
                warior1.ShowInfo();
                Console.WriteLine();
                Console.Write("Варвар\n");
                warior2.ShowInfo();
                Console.WriteLine();
                hits++;
            }
            if (warior2.Health <= 0)
            {
                Console.WriteLine($"{warior2.Name} пал!");
                Console.WriteLine($"Победитель: {warior1.Name}!");
            }
            else if (warior1.Health <= 0)
            {
                Console.WriteLine($"{warior1.Name} пал!");
                Console.WriteLine($"Победитель: {warior2.Name}!");
            }
        }
    }


    class Warior
    {
        public double Health;
        public double Armor;
        public double Damage;

        public Warior(int health, double armor, double damage)
        {
            Health = health;
            Armor = armor;
            Damage = damage;
        }

        public void TakeDamage(double damage)
        {
            Health -= damage - Armor;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Здоровья: {Health}\nУрона: {Damage}\nБрони: {Armor}");
        }

    }

    class Knight : Warior
    {
        public string Name = "Великий Рыцарь";
        public Knight(int health, double armor, double damage) : base(health, armor, damage) { }

        public void Pray()
        {
            Armor += 1;
            Console.WriteLine("Рыцарь благославлён. Броня +1\nБроня рыцаря: " + Armor);
        }
    }

    class Barbarian : Warior
    {
        public string Name = "Храбрый Варвар";
        private double AtackSpeed;
        public Barbarian(int health, double armor, double damage, double atackSpeed) : base(health, armor, damage)
        {
            AtackSpeed = atackSpeed;
            Damage += AtackSpeed * Damage;
        }

        public void Shout()
        {
            Armor -= 1;
            Health += 10;
            Console.WriteLine("Варвар кричит. Броня -1, Здровье +10\nБроня Варвара: " + Armor + "\nЗдоровье Варвара: " + Health);
        }
    }
}