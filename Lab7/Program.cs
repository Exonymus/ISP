using System;

namespace Lab7
{
    class Program
    {
        public static void Menu()
        {
            Console.Clear();

            Console.WriteLine("1. Сложение(+)\n2. Вычитание(-)" +
            "\n3. Умножение(*)\n4. Деление(/)" +
            "\n5. Проверка на знак < \n6. Проверка на знак  >" +
            "\n7. Отсортировать(в массиве с 2/3 и 3/4) \n8. Проверка на равенство чисел" +
            "\n9. Преобразовать в double \n0. Выход");
        }

        static void Main()
        {
            Console.WriteLine("Введите 1-ую дробь(x/y): ");
            string number = Console.ReadLine();
            Console.WriteLine("Введите 2-ую дробь(x/y): ");
            string number2 = Console.ReadLine();

            Converter.ToConverter(number, out Converter firstnum);
            Converter.ToConverter(number2, out Converter secondnum);

            Converter forcase1 = new Converter(2, 3);
            Converter forcase2 = new Converter(3, 4);

            Converter[] mass = new Converter[] { firstnum, secondnum, forcase1, forcase2 };
            Menu();

            int choose;
            do
            {
                choose = Console.Read() - 48;
                Console.Write("\b");

                switch (choose)
                {
                    case 1:
                        Console.WriteLine($"Сумма: {firstnum + secondnum}");
                        break;

                    case 2:
                        Console.WriteLine($"Разность: {firstnum - secondnum}");
                        break;

                    case 3:
                        Console.WriteLine($"Произведение: {firstnum * secondnum}");
                        break;

                    case 4:
                        Console.WriteLine($"Частное: {firstnum / secondnum}");
                        break;

                    case 5:
                        Console.WriteLine($"{firstnum} < {secondnum} = {firstnum < secondnum}");
                        break;

                    case 6:
                        Console.WriteLine($"{firstnum} > {secondnum} = {firstnum > secondnum}");
                        break;

                    case 7:
                        Array.Sort(mass);
                        foreach (var i in mass)
                            Console.WriteLine($"{i}");
                        break;

                    case 8:
                        Console.WriteLine($"Числа равны: {firstnum.Equals(secondnum)}");
                        break;

                    case 9:
                        double one = (double)firstnum;
                        Console.WriteLine($"{one} : {firstnum}");
                        double two = (double)secondnum;
                        Console.WriteLine($"{two} : {secondnum}");
                        break;

                    case 0:
                        return;

                    default:
                        Console.Write("\b");
                        break;
                }
            } while (true);
        }
    }
}