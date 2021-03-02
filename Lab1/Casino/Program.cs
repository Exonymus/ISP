using System;

namespace Casino
{
    class Balance
    {
        public int coins;
        public int keys;

        public Balance()
        {
            coins = 1000;
            keys = 0;
        }
        public int check(bool key)
        {
            if (key)
                return keys;
            else
                return coins;
        }
    }

    class Player
    {
        Balance bal;
        int wins;
        int losses;

        public Player()
        {
            bal = new Balance();
            wins = 0;
            losses = 0;
        }

        public int showbal(Player pl, bool keys)
        {
            if (keys)
                return pl.bal.check(true);
            else
                return pl.bal.check(false);
        }
        public void statchange(Player pl, bool win)
        {
            if (win)
                pl.wins++;
            else
                pl.losses++;
        }
        public int showstat(Player pl, bool win)
        {
            if (win)
                return pl.wins;
            else
                return pl.losses;

        }
        public void Bal_change(Player pl, bool key)
        {
            if (key)
                pl.bal.keys -= 3;
            else
                pl.bal.coins -= 100;
        }
        public void reward(Player pl, int result)
        {
            pl.bal.coins += result;
        }
        public void convert(Player pl)
        {
            if (pl.bal.coins - 3 * 30 < 0)
                Console.WriteLine("\nВы не можете себе этого позволить :(");
            else
            {
                pl.bal.keys += 3;
                pl.bal.coins -= 3 * 30;
                Console.WriteLine("\nУспешно!");
            }
        }
    }

    class Casino
    {
        private static int check_T(int ch)
        {
            int[] nums = new int[9] { 49, 50, 51, 52, 53, 54, 55, 56, 57 };
            bool correct = false;
            if (ch != nums[0] && ch != nums[1] && ch != nums[2] &&
                ch != nums[3] && ch != nums[4] && ch != nums[5] &&
                ch != nums[6] && ch != nums[7] && ch != nums[8])
                while (!correct)
                {
                    Console.Write("\b");
                    ch = Convert.ToInt32(Console.Read());
                    if (ch == nums[0] || ch == nums[1] || ch == nums[2] ||
                        ch == nums[3] || ch == nums[4] || ch == nums[5] ||
                        ch == nums[6] || ch == nums[7] || ch == nums[8])
                        correct = true;
                }
            return ch;
        }

        private static int check_C(int ch)
        {
            int[] nums = new int[3] { 49, 50, 51 };
            bool correct = false;
            if (ch != nums[0] && ch != nums[1] && ch != nums[2])
                while (!correct)
                {
                    Console.Write("\b");
                    ch = Convert.ToInt32(Console.Read());
                    if (ch == nums[0] || ch == nums[1] || ch == nums[2])
                        correct = true;
                }
            return ch;
        }

        public static int Thief(Player pl)
        {
            Random rnd = new Random();
            int result = 0;
            if (pl.showbal(pl, true) < 3)
            {
                Console.WriteLine("Пополните ваш баланс ключей!");
                return result;
            }
            else
                pl.Bal_change(pl, true);

            int ch1, ch2, ch3;
            int code = 0, code_1 = 0, code_2 = 0, code_3 = 0;
            bool correctval = false;

            while (!correctval)
            {
                code = rnd.Next(100, 1000);
                code_1 = code / 100;
                code_2 = code / 10 % 10;
                code_3 = code % 10;

                if ((code_1 != code_2) && (code_2 != code_3) && (code_1 != code_3))
                    correctval = true;
                if ((code_1 * code_2 * code_3) == 0)
                    correctval = false;
            }
            Console.WriteLine("У вас 3 попытки подобрать числа последовательности:");
            Console.WriteLine("...................................................");
            Console.WriteLine("................███████████████....................");
            Console.WriteLine("................█.............█....................");
            Console.WriteLine("................█.............█....................");
            Console.WriteLine("................█....█████....█....................");
            Console.WriteLine("................█....█@@@█....█....................");
            Console.WriteLine("................█....█████....█....................");
            Console.WriteLine("................█.............█....................");
            Console.WriteLine("................█.............█....................");
            Console.WriteLine("................███████████████....................");
            Console.WriteLine("...................................................");

            for (int i = 0; i < 3; i++)
            {
                Console.Write("Введите 3 разные цифры(Например: 123): ");

                ch1 = Convert.ToInt32(Console.Read());
                ch1 = check_T(ch1) - 48;
                ch2 = Convert.ToInt32(Console.Read());
                ch2 = check_T(ch2) - 48;
                ch3 = Convert.ToInt32(Console.Read());
                ch3 = check_T(ch3) - 48;

                int[] check = new int[3] { ch1, ch2, ch3 };

                if (((ch1 == code_1) && (ch2 == code_2) && (ch3 == code_3)) ||
                    ((ch1 == code_2) && (ch2 == code_1) && (ch3 == code_3)) ||
                    ((ch1 == code_3) && (ch2 == code_2) && (ch3 == code_1)) ||
                    ((ch1 == code_1) && (ch2 == code_3) && (ch3 == code_2)) ||
                    ((ch1 == code_3) && (ch2 == code_1) && (ch3 == code_2)) ||
                    ((ch1 == code_2) && (ch2 == code_3) && (ch3 == code_1)))
                {
                    Console.WriteLine("\nПоздравляем! Вы угадали цифры кода!");
                    Console.WriteLine($"Код был: {code}");
                    pl.statchange(pl, true);
                    result = 180;
                    return result;
                }

                for (int k = 0; k < 3; k++)
                {

                    if (code_1 == check[k])
                        Console.Write($"\n{k + 1} цифра в коде есть!");
                    if (code_2 == check[k])
                        Console.Write($"\n{k + 1} цифра в коде есть!");
                    if (code_3 == check[k])
                        Console.Write($"\n{k + 1} цифра в коде есть!");
                }

                if (i == 0)
                    Console.WriteLine("\nУ вас осталась 2 попытки!");
                else if (i == 1)
                    Console.WriteLine("\nУ вас осталась 1 попытка!");
            }
            if (result == 0)
            {
                Console.WriteLine("\nК сожалению вы проиграли :(");
                Console.WriteLine($"Код был: {code}");
                pl.statchange(pl, false);
            }
            return result;
        }

        public static int Cups(Player pl)
        {
            int result = 0;
            Random rnd = new Random();
            if (pl.showbal(pl, false) < 100)
            {
                Console.WriteLine("К сожалению у вас недостаточно денег :(");
                return result;
            }
            else
                pl.Bal_change(pl, false);

            Console.WriteLine("~~~~~~~~Выберите 1 из 3-х наперстков~~~~~~~~");
            Console.WriteLine("............................................");
            Console.WriteLine(".........███.........███........███.........");
            Console.WriteLine("........█...█.......█...█......█...█........");
            Console.WriteLine("........█...█.......█...█......█...█........");
            Console.WriteLine("............................................");
            Console.WriteLine("..........I...........II........III.........");
            Console.WriteLine("............................................");
            int choice;
            int answer = rnd.Next(49, 52);

            choice = Convert.ToInt32(Console.Read());
            choice = check_C(choice);

            if (choice == answer)
            {
                result = 200;
                Console.WriteLine("\nУра! Вы выйграли 100 монет!");
                pl.statchange(pl, true);
            }
            else
            {
                Console.WriteLine("\nК сожалению вы проиграли :(\nШарик был в {0} наперстке\n", answer - 48);
                pl.statchange(pl, false);
            }
            return result;
        }
    }
    class MainClass
    {
        private static int Check_C(int ch)
        {
            int[] nums = new int[5] { 49, 50, 51, 52, 53 };
            bool correct = false;
            if (ch != nums[0] && ch != nums[1] && ch != nums[2] && ch != nums[3] && ch != nums[4])
                while (!correct)
                {
                    Console.Write("\b");
                    ch = Convert.ToInt32(Console.Read());
                    if (ch == nums[0] || ch == nums[1] || ch == nums[2] || ch == nums[3] || ch == nums[4])
                        correct = true;
                }
            return ch;
        }
        static void printmenu()
        {
            Console.WriteLine("............................................");
            Console.WriteLine("***************|Главное Меню|***************");
            Console.WriteLine("....|1 - > Просмотреть Статистику Игрока....");
            Console.WriteLine("....|2 - > Сыграть в Медвежатника(3 ключа)..");
            Console.WriteLine("....|3 - > Сыграть в Наперстки(100 монет)...");
            Console.WriteLine("....|4 - > Обменять 3 ключа по 30 монет.....");
            Console.WriteLine("....|5 - > Выход из Программы...............");
            Console.WriteLine("............................................");
        }
        static void back()
        {
            int choice;
            Console.Write("Нажмите 0, чтобы вернуться назад");

            choice = Convert.ToInt32(Console.Read());
            while (choice != 48)
            {
                Console.Write("\b");
                choice = Convert.ToInt32(Console.Read());
            }
            Console.Clear();
            printmenu();
            Console.Write("Выберите пункт:");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("~~~~~~~|Казино Азартного программиста|~~~~~~");
            Player Player = new Player();
            Casino cas = new Casino();

            int choice;

            printmenu();
            Console.Write("Выберите пункт:");

            choice = Convert.ToInt32(Console.Read());
            choice = Check_C(choice);
            while (choice != 53)
            {
                switch (choice)
                {
                    case 49:
                        {
                            Console.Clear();
                            Console.WriteLine("............................................");
                            Console.WriteLine("*************|Статистика Игрока|************");
                            Console.WriteLine("...........| Побед:           {0} |...........", Player.showstat(Player, true));
                            Console.WriteLine("...........| Поражений:       {0} |...........", Player.showstat(Player, false));
                            Console.WriteLine("...........| Баланс монет: {0} |...........", Player.showbal(Player, false));
                            Console.WriteLine("...........| Баланс ключей:   {0} |...........", Player.showbal(Player, true));
                            Console.WriteLine("............................................");
                            back();
                            break;
                        }
                    case 50:
                        {
                            Console.Clear();
                            Player.reward(Player, Casino.Thief(Player));
                            back();
                            break;
                        }
                    case 51:
                        {
                            Console.Clear();
                            Player.reward(Player, Casino.Cups(Player));
                            back();
                            break;
                        }
                    case 52:
                        {
                            Player.convert(Player);
                            break;
                        }
                    default:
                        Console.Write("\b");
                        break;
                }
                choice = Convert.ToInt32(Console.Read());
            }

        }
    }
}
