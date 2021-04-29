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

    class Sportsman : Human
    {
        public string Country { get; set; }

        public int Awards { get; set; }
        public double Salary { get; set; }

        protected int skillLevel;
        protected int equipLevel;
        protected int experience;

        public Sportsman() { Country = "Беларусь"; Awards = 1; Salary = 0; experience = 0; skillLevel = 0; equipLevel = 0;}

        public Sportsman(Human person) : base(person) { }
        public Sportsman(Human person, string country, int awards, double salary) : base(person)
        {
            Country = country;
            Awards = awards;
            if (Awards > 1)
                skillLevel = awards / 2;
            else
                skillLevel = 1;
            experience = 0;
            equipLevel = 0;
            Salary = salary;
        }

        public Sportsman(Human person, string country, int awards) : base(person)
        {
            Country = country;
            Awards = awards;
            if (Awards > 1)
                skillLevel = awards / 2;
            else
                skillLevel = 1;
            experience = 0;
            equipLevel = 0;
            Salary = 0;
        }

        public void GetSalary()
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

        public virtual void train(int time)
        {
            experience += Convert.ToInt32(time * 0.5) + equipLevel * 20;
            if (experience >= 100)
            {
                skillLevel++;
                experience -= 100;
            }
        }

        public virtual void Compete()
        {
            if (skillLevel < 10)
            {
                Console.WriteLine("Вы еще слишком неопытны для участия в соревновании!");
                return;
            }

            double winChance = (100 + skillLevel) / 2 + equipLevel * 3.5;
            Random rand = new Random();

            if (rand.Next(100) < winChance)
            {
                Awards++;
                experience += 50;
            }
            else
                experience += 5;

            if (experience >= 100)
            {
                skillLevel++;
                experience -= 100;
            }
        }

        public virtual void upgradeEquipment()
        {
            if (Money >= equipLevel * 100)
            {
                equipLevel++;
                Money -= equipLevel * 100;
            }
            else
                Console.WriteLine("Вы не можете себе этого позволить!");
        }

        public void AllInfo()
        {
            Console.WriteLine($"Имя: {Name}\nФамилия: {Surname}\nПол: {Sex}\nВозраст: {Age}\nДеньги: {Money} руб.");
            Console.WriteLine($"Страна: {Country}\nНаград: {Awards}\nЗарплата: {Salary}\nУровень навыка: {skillLevel}\nОпыт: {experience}");
        }
    }

    sealed class FootballPlayer : Sportsman
    {
        public FootballPlayer(Sportsman sp)
        {
            Country = sp.Country;
            Name = sp.Name;
            Surname = sp.Surname;
            Age = sp.Age;
            Sex = sp.Sex;
            Awards = sp.Awards;
            experience = 0;
            skillLevel = 0;
            equipLevel = 0;
            Salary = 50;
        }

        public override void train(int time)
        {
            Random rand = new Random();
            if (rand.Next(10) > 3)
                base.train(time);
            else
                Console.WriteLine("К сожалению сегодня плохая погода, и тренировку отменили.");
        }

        public override void Compete()
        {
            int exp = experience;
            base.Compete();
            if (experience - exp == 50)
            {
                Console.WriteLine("Вы победили в матче");
                Salary += 10;
            }
            else
                if (experience != exp)
                    Console.WriteLine("Противники оказались сильнее и вы проиграли");

            Random rand = new Random();
            if (rand.Next(5) == 3)
            {
                Console.WriteLine("К сожалению во время матча вы получили травму!");
                if (skillLevel - 2 > 0)
                    skillLevel -= 2;
                else
                    Console.WriteLine("Но ваша целеустремленность не позволило вам играть хуже!");
            }
        }

        public override void upgradeEquipment()
        {
            if (Money >= equipLevel * 150)
            {
                equipLevel++;
                Money -= equipLevel * 150;
            }
            else
                Console.WriteLine("Вы не можете себе этого позволить!");
        }

    }

    sealed class Swimmer : Sportsman
    {
        public Swimmer(Sportsman sp)
        {
            Country = sp.Country;
            Awards = sp.Awards;
            Name = sp.Name;
            Surname = sp.Surname;
            Age = sp.Age;
            Sex = sp.Sex;
            experience = 0;
            skillLevel = 0;
            equipLevel = 0;
            Salary = 20;
        }

        public override void train(int time)
        {
            base.train(time);
            Random rand = new Random();
            if (rand.Next(10) < 3)
            {
                Console.WriteLine("К сожалению сегодня бассейн буквально переполнен и вы плохо тренировались");
                if (experience - 15 >= 0)
                    experience -= 15;
            }
        }

        public override void Compete()
        {
            int exp = experience;
            base.Compete();
            if (experience - exp == 50)
            {
                Console.WriteLine("Вы победили в  заплыве");
                Salary += 15;
            }
            else
                if (experience != exp)
                    Console.WriteLine("Противники оказались быстрее и вы проиграли");
        }

        public override void upgradeEquipment()
        {
            if (Money >= equipLevel * 50)
            {
                equipLevel++;
                Money -= equipLevel * 50;
            }
            else
                Console.WriteLine("Вы не можете себе этого позволить!");
        }
    }

    sealed class HockeyPlayer : Sportsman
    {
        public HockeyPlayer(Sportsman sp)
        {
            Country = sp.Country;
            Name = sp.Name;
            Surname = sp.Surname;
            Age = sp.Age;
            Sex = sp.Sex;
            Awards = sp.Awards;
            Money = 100;
            experience = 0;
            skillLevel = 0;
            equipLevel = 0;
            Salary = 70;
        }

        public override void train(int time)
        {
            if (Money < 20)
            {
                Console.WriteLine($"Вам не хватает денег на медстраховку, чтобы дальше тренироваться, вам нужно еще заработать {20 - Money} руб!");
                return;
            }

            base.train(time);

            Random rand = new Random();
            if (rand.Next(10) < 3)
            {
                Console.WriteLine("На тренировке вы получили травмы и вам пришлось купить лекарства на 20 руб!");
                Money -= 20;
            }

        }

        public override void Compete()
        {
            int exp = experience;
            base.Compete();
            if (experience - exp == 50)
            {
                Console.WriteLine("Вы победили в матче");
                Salary += 30;
            }
            else
                if (experience != exp)
                    Console.WriteLine("Противники оказались сильнее и вы проиграли");

            Random rand = new Random();
            if (rand.Next(5) == 3)
            {
                Console.WriteLine("К сожалению во время матча вы получили травму!");
                if (skillLevel - 2 > 0)
                    skillLevel -= 2;
                else
                    Console.WriteLine("Но ваша целеустремленность не позволило вам играть хуже!");
            }
        }

        public override void upgradeEquipment()
        {
            if (Money >= equipLevel * 200)
            {
                equipLevel++;
                Money -= equipLevel * 200;
            }
            else
                Console.WriteLine("Вы не можете себе этого позволить!");
        }

    }


    class MainClass
    {
        public static void printMenu()
        {
            Console.WriteLine("1 - Тренироваться");
            Console.WriteLine("2 - Учавствовать в соревновании");
            Console.WriteLine("3 - Улучшить экипировку");
            Console.WriteLine("4 - Информация");
            Console.WriteLine("0 - Выход");
        }
        public static void Main(string[] args)
        {
           

            Human woman = new Human("Анна", "Иванова", "Женщина", 32);
            Sportsman sp1 = new Sportsman(woman, "Россия", 13);
            Sportsman sp2 = new Sportsman(new Human("Джошуа", "Абрамович", "Мужчина", 20));
            

            int choice = 0, sportCh = 0, salTime = 0;

            Console.WriteLine("Сделайте выбор: Футбол(1), Хоккей(2), или Плавание(3): ");
            while (sportCh != 49 && sportCh != 50 && sportCh != 51)
            {
                sportCh = Console.Read();
                if (sportCh != 49 && sportCh != 50 && sportCh != 51)
                    Console.Write("\b");
            }

            FootballPlayer fb = new FootballPlayer(sp2);
            HockeyPlayer hp = new HockeyPlayer(new Sportsman(new Human("Евгений", "Сергеев", "Мужчина", 26)));
            Swimmer sw = new Swimmer(sp1);

            Console.Clear();

            printMenu();
            while (choice != 48)
            {
                if (salTime == 5)
                {
                    if (sportCh == 49)
                        fb.GetSalary();
                    else if (sportCh == 50)
                        hp.GetSalary();
                    else if (sportCh == 51)
                        sw.GetSalary();
                    salTime = 0;
                }

                choice = Convert.ToInt32(Console.Read());
                switch (choice)
                {
                    case 49:
                        Console.Write("\b");
                        if (sportCh == 49)
                            fb.train(100);
                        else if (sportCh == 50)
                            hp.train(100);
                        else if (sportCh == 51)
                            sw.train(100);
                        salTime++;
                        break;

                    case 50:
                        Console.Write("\b");
                        if (sportCh == 49)
                            fb.Compete();
                        else if (sportCh == 50)
                            hp.Compete();
                        else if (sportCh == 51)
                            sw.Compete();
                        salTime++;
                        break;

                    case 51:
                        Console.Write("\b");
                        if (sportCh == 49)
                            fb.upgradeEquipment();
                        else if (sportCh == 50)
                            hp.upgradeEquipment();
                        else if (sportCh == 51)
                            sw.upgradeEquipment();
                        salTime++;
                        break;

                    case 52:
                        Console.Clear();
                        if (sportCh == 49)
                            fb.AllInfo();
                        else if (sportCh == 50)
                            hp.AllInfo();
                        else if (sportCh == 51)
                            sw.AllInfo();
                        Console.ReadKey();
                        Console.Clear();
                        printMenu();
                        break;

                    default:
                        break;
                }
               
            }


            Console.ReadKey();
        }
    }
}
