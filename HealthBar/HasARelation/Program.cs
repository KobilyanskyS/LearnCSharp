namespace HasARelation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Performer performer1 = new Performer("Пупа");
            Performer performer2 = new Performer("Лупа");

            Task[] tasks = { new Task(performer1, "Вскопать грядку"), new Task(performer2, "Чиллить") };

            Board schedule = new Board(tasks);

            schedule.ShowAllTasks();
        }
    }
    class Performer
    {
        public string Name;

        public Performer(string name)
        {
            Name = name;
        }
    }

    class Board
    {
        public Task[] Tasks;

        public Board(Task[] tasks)
        {
            Tasks = tasks;
        }

        public void ShowAllTasks()
        {
            for (int i = 0; i < Tasks.Length; i++)
            {
                Tasks[i].ShowInfo();
            }
        }

    }

    class Task
    {
        public Performer Worker;
        public string Description;

        public Task(Performer worker, string description)
        {
            Description = description;
            Worker = worker;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Задача: {Description}\nИсполнитель: {Worker.Name}\n\n");
        }
    }
}