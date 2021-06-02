using System;
namespace Lab5
{
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
            Salary = 20;
        }

        public override void Train(int time)
        {
            base.Train(time);
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

        public override void UpgradeEquipment()
        {
            int sum = equipLevel * 50;
            if (Money >= sum)
            {
                Money -= sum;
                equipLevel++;
            }
            else
                Console.WriteLine("Вы не можете себе этого позволить!");
        }
    }
}
