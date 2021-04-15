using System;
using System.Runtime.InteropServices;

namespace Lab4_Task2
{
    class Program
    {
        [DllImport("C:\\C#\\Lab4\\Dll\\Dll1\\Debug\\Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Max(double a, double b);
        [DllImport("C:\\C#\\Lab4\\Dll\\Dll1\\Debug\\Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        static extern double Abs(double a);
        [DllImport("C:\\C#\\Lab4\\Dll\\Dll1\\Debug\\Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        static extern int Floor(double a);
        [DllImport("C:\\C#\\Lab4\\Dll\\Dll1\\Debug\\Dll1.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Pow(double a, int b);
        [DllImport("C:\\C#\\Lab4\\Dll\\Dll1\\Debug\\Dll1.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int Fact(int a);
        [DllImport("C:\\C#\\Lab4\\Dll\\Dll1\\Debug\\Dll1.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern double Percentage(double a, double b);

        static int InputChecker()
        {
            string n;
            for (;;)
            {
                n = Console.ReadLine();
                bool check = Int32.TryParse(n, out int ni);
                if (check) 
                    return ni;
                Console.WriteLine("\nНекорректный ввод, попробуйте снова");
            }
        }
        static void Main(string[] args)
        {
            double first, second;
            int n, num;
            while (true)
            {
                Console.WriteLine("1. Округление вниз.\n2. Процентное соотношение.\n3. Модуль.\n4. Возведение в степень.\n5. Факториал.\n6. Максимум из 2 чисел.\n7. Выход.");
                Console.Write("Выберите пункт: ");
                n = InputChecker();

                switch (n)
                {
                    case 1:
                        Console.Write("\nВведите число: ");
                        first = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Результат: {Floor(first)}");
                        break;

                    case 2:
                        Console.Write("\nВведите первое число: ");
                        first = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        second = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Результат: {Percentage(first, second)}%");
                        break;

                    case 3:
                        Console.Write("\nВведите число: ");
                        first = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Результат: {Abs(first)}");
                        break;

                    case 4:
                        Console.Write("\nВведите число: ");
                        first = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите степень: ");
                        num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Результат: {Pow(first, num)}");
                        break;
                    case 5:
                        Console.Write("\nВведите число: ");
                        num = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Результат: {Fact(num)}");
                        break;
                    case 6:
                        Console.Write("\nВведите число: ");
                        Console.Write("\nВведите первое число: ");
                        first = Convert.ToDouble(Console.ReadLine());
                        Console.Write("Введите второе число: ");
                        second = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine($"Результат: {Max(first, second)}");
                        break;
                    case 7:
                        return;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
