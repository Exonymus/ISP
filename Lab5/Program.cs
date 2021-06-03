using System;

namespace Lab5
{
    interface ISport
    {
        void Train(int time);
        void Compete();
        void UpgradeEquipment();
    }

    class Menu
    {
        public static void printMenu()
        {
            Console.WriteLine("1 - Тренироваться");
            Console.WriteLine("2 - Учавствовать в соревновании");
            Console.WriteLine("3 - Улучшить экипировку");
            Console.WriteLine("4 - Информация");
            Console.WriteLine("0 - Выход");
        }

        public static int getChoice(int choice)
        {
            Console.WriteLine("Сделайте выбор: Футбол(1), Хоккей(2), или Плавание(3): ");
            while (choice != 49 && choice != 50 && choice != 51)
            {
                choice = Console.Read();
                if (choice != 49 && choice != 50 && choice != 51)
                    Console.Write("\b");
            }
            Console.Clear();
            return choice;
        }
    }

    class MainClass
    {
        
        public static void Main(string[] args)
        { 
            Human woman = new Human("Анна", "Иванова", "Женщина", 32);

            int choice = 0, sportCh = 0, salTime = 0;

            FootballPlayer fb = new FootballPlayer(new Sportsman(new Human("Джошуа", "Абрамович", "Мужчина", 20)));
            HockeyPlayer hp = new HockeyPlayer(new Sportsman(new Human("Евгений", "Сергеев", "Мужчина", 26)));
            Swimmer sw = new Swimmer(new Sportsman(woman, "Россия", 13));

            fb.Xp += delegate (int xp)
            {
                Console.WriteLine($"Вы получили : {xp} оп.");
            };
            hp.Xp += (xp) => Console.WriteLine($"Вы получили : {xp} оп.");
            sw.Xp += (xp) => Console.WriteLine($"Вы получили : {xp} оп.");

            Sportsman[] player = {fb, hp, sw};

            sportCh = Menu.getChoice(sportCh);
            Menu.printMenu();

            while (choice != 48)
            {
                if (salTime == 5)
                {
                    player[sportCh - 49].GetSalary();
                    salTime = 0;
                }

                choice = Convert.ToInt32(Console.Read());
                switch (choice)
                {
                    case 49:
                        Console.Write("\b");
                        player[sportCh - 49].Train(100);
                        salTime++;
                        break;

                    case 50:
                        Console.Write("\b");
                        player[sportCh - 49].Compete();
                        salTime++;
                        break;

                    case 51:
                        Console.Write("\b");
                        player[sportCh - 49].UpgradeEquipment();
                        break;

                    case 52:
                        Console.Clear();
                        player[sportCh - 49].AllInfo();

                        if (player[sportCh - 49].CompareTo(hp) > 0)
                            Console.WriteLine("Вы достигли больших успехов!");
                        else if (player[sportCh - 49].CompareTo(hp) < 0)
                            Console.WriteLine("Вы пока не очень продвинулись в спорте!");
                        else if (player[sportCh - 49].CompareTo(hp) == 0)
                            Console.WriteLine("Вы неплохо продвинулись в спорте!");

                        Console.ReadKey();
                        Console.Clear();
                        Menu.printMenu();
                        break;

                    default:
                        break;
                }
               
            }
            Console.ReadKey();
        }
    }
}
