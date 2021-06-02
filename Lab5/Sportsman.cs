using System;
namespace Lab5
{
    internal class Sportsman : Human, ISport, IComparable
    {
        public string Country { get; set; }

        public int Awards { get; set; }
        public double Salary { get; set; }

        protected int skillLevel;
        protected int equipLevel;
        protected int experience;

        public Sportsman() { Country = "Беларусь"; Awards = 1; Salary = 0; experience = 0; skillLevel = 0; equipLevel = 0; }

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
            equipLevel = 1;
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

        public virtual void Train(int time)
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

        public virtual void UpgradeEquipment()
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
            Console.WriteLine($"Страна: {Country}\nНаград: {Awards}\nЗарплата: {Salary}\nУровень навыка: {skillLevel}");
            Console.WriteLine($"Опыт: {experience}\nУровень экипировки: {equipLevel}");
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 1;

            if (obj is Sportsman sp)
                return Awards.CompareTo(sp.Awards);
            else
                throw new ArgumentException("Некорректный объект");
        }
    }
}
