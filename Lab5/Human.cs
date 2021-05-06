using System;
namespace Lab5
{
    class Human
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
        protected double Money { get; set; }

        public int ID { get; private set; }
        private static int Count;

        public Human() : this("Иван", "Иванов", "Мужчина", 18, 0)
        {
            ID = Count;
            Count++;
        }

        public Human(Human add)
        {
            Name = add.Name;
            Surname = add.Surname;
            Sex = add.Sex;
            Age = add.Age;
            Money = add.Money;
            ID = Count;
            Count++;
        }

        public Human(string name, string surname, string sex, int age, double money)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            Age = age;
            Money = money;
            ID = Count;

        }

        public Human(string name, string surname, string sex, int age)
        {
            Name = name;
            Surname = surname;
            Sex = sex;
            Age = age;
            Money = 0;
            ID = Count;

        }

        public void Info()
        {
            Console.WriteLine($"Имя: {Name}\nФамилия: {Surname}\nПол: {Sex}\nВозраст: {Age}\nДеньги: {Money} руб.");
        }

        public void shortInfo()
        {
            Console.WriteLine($"{Name} {Surname}, {Sex}, {Age} лет, ID = {ID}");
        }

        public void getCount()
        {
            Console.WriteLine(Count);
        }
    }
}
