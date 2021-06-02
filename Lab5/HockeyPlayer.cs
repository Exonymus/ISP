using System;
namespace Lab5
{
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
            Salary = 70;
        }

        public override void Train(int time)
        {
            if (Money < 20)
            {
                Console.WriteLine($"Вам не хватает денег на медстраховку, чтобы дальше тренироваться, вам нужно еще заработать {20 - Money} руб!");
                return;
            }

            base.Train(time);

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

        public override void UpgradeEquipment()
        {
            int sum = equipLevel * 200;
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
