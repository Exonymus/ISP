using System;

namespace Task
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Дата в формате 1: ");
            string timeFirst = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            int[] numFirst = new int[10];
            Console.WriteLine($"{timeFirst}");

            int i = 0;
            while(i < timeFirst.Length)
            {
                if ((Convert.ToInt32(timeFirst[i]) >= 48) && (Convert.ToInt32(timeFirst[i]) <= 57))
                    numFirst[Convert.ToInt32(timeFirst[i]) - 48]++;
                i++;
            }
            i = 0;

            for (int k = 0; k < 10; k++)
                Console.WriteLine($"Число {k} в дате: {numFirst[k]}");

            Console.WriteLine("Дата в формате 2: ");
            string timeSecond = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz");
            int[] numSecond = new int[10];
            Console.WriteLine($"{timeSecond}");

            while (i < timeSecond.Length)
            {
                if ((Convert.ToInt32(timeSecond[i]) >= 48) && (Convert.ToInt32(timeSecond[i]) <= 57))
                    numSecond[Convert.ToInt32(timeSecond[i]) - 48]++;
                i++;
            }

            for (int k = 0; k < 10; k++)
                Console.WriteLine($"Число {k} в дате: {numSecond[k]}");
            Console.ReadKey();
        }
    }
}
