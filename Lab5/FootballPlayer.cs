using System;
namespace Lab5
{
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
            Salary = 50;
        }

        public override void Train(int time)
        {
            Random rand = new Random();
            if (rand.Next(10) > 3)
                base.Train(time);
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
            int sum = equipLevel * 150;
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
