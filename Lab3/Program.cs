using System;

namespace Lab3
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

    class Sportsman : Human
    {
        public string Country { get; set; }

        public int Awards { get; set; }
        public double Salary { get; set; }

        public Sportsman() { Country = "Беларусь"; Awards = 1; Salary = 0; }

        public Sportsman(Human person) : base(person) { }
        public Sportsman(Human person, string country, int awards, double salary) : base(person)
        {
            Country = country;
            Awards = awards;
            Salary = salary;
        }

        public Sportsman(Human person, string country, int awards) : base(person)
        {
            Country = country;
            Awards = awards;
            Salary = 0;
        }

        public void getSalary()
        {
            if (Salary == 0)
            {
                Console.WriteLine($"К сожалению, спортсмен {Name} {Surname} безработный и не получает зарплату.");
            }
            else
            {
                Money += Salary;
                Console.WriteLine($"Спортсмен {Name} {Surname} заработал {Salary} руб.! Теперь у него: {Money} руб.");
            }
        }

        public void sportsInfo()
        {
            Console.WriteLine($"Страна: {Country}\nНаград: {Awards}\nЗарплата: {Salary}");
        }
    }

    class Specialist
    {
        public string Sport { get; set; }

        Sportsman[] sportsmen;

        public Specialist(int count)
        {
            sportsmen = new Sportsman[count];
        }

        public Sportsman this[int index]
        {
            get
            {
                return sportsmen[index];
            }

            set
            {
                sportsmen[index] = value;
            }
        }

        public void fullInfo()
        {
            Console.WriteLine($"Полная информация про {Sport}:");
            for (int i = 0; i < sportsmen.Length; i++)
            {
                if (sportsmen[i] == null)
                    continue;
                sportsmen[i].shortInfo();
            }
        }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Sportsman sp = new Sportsman();

            sp.Info();
            sp.sportsInfo();
            sp.getSalary();
            sp.Salary += 500;
            sp.getSalary();
            sp.Info();

            Human woman = new Human("Анна", "Иванова", "Женщина", 32);
            Sportsman sp1 = new Sportsman(woman, "Россия", 13);
            Sportsman sp2 = new Sportsman(new Human("Джошуа", "Абрамович", "Мужчина", 20));

            Specialist swim = new Specialist(3);
            swim[0] = sp;
            swim[1] = sp1;
            swim[2] = sp2;
            swim.Sport = "Плавание";
            swim.fullInfo();
            Console.WriteLine();

            Console.Write("Введите название спорта: ");
            string specialty = Console.ReadLine();
            Console.Write("Введите кол-во спортсменов: ");
            int amount = Convert.ToInt32(Console.ReadLine());
            Specialist another = new Specialist(amount);
            another.Sport = specialty;
            for (int i = 0; i < amount; i++)
            {
                Console.Write($"Введите имя {i + 1}-го спортсмена: ");
                string name = Console.ReadLine();
                Console.Write($"Введите фамилию {i + 1}-го спортсмена: ");
                string surname = Console.ReadLine();
                Console.Write($"Введите пол {i + 1}-го спортсмена: ");
                string sex = Console.ReadLine();
                Console.Write($"Введите возраст {i + 1}-го спортсмена: ");
                int age = Convert.ToInt32(Console.ReadLine());
                another[i] = new Sportsman(new Human(name, surname, sex, age));

            }
            another.fullInfo();
            Console.ReadKey();
        }
    }
}
