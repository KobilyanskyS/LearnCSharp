namespace Up_Downcasting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Student("Jim", 5);

            switch (person)
            {
                case Mentor mentor:
                    mentor.ShowName();
                    Console.WriteLine(mentor.NumberOfStudents);
                    break;
                case Student student:
                    student.ShowName();
                    Console.WriteLine(student.AvarageScore);
                    break;
            }
        }
    }

    class Person
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public void ShowName() 
        { 
            Console.WriteLine("Я - " + Name);
        }
    }

    class Mentor : Person
    {
        public int NumberOfStudents
        {
            get; private set;
        }
        public Mentor(string name, int numberOfStudents) : base(name)
        {
            NumberOfStudents = numberOfStudents;
        }
    }

    class Student : Person
    {
        public int AvarageScore { get; private set; }

        public Student(string name, int avarageScore) : base(name)
        {
            AvarageScore = avarageScore;
        }
    }

}