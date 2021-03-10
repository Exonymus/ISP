using System;

namespace Task
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Дата в формате 1: ");
            string time1 = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
            int[] num1 = new int[10];
            Console.WriteLine($"{time1}");

            int i = 0;
            while(i < time1.Length)
            {
                if ((Convert.ToInt32(time1[i]) >= 48) && (Convert.ToInt32(time1[i]) <= 57))
                    num1[Convert.ToInt32(time1[i]) - 48]++;
                i++;
            }
            i = 0;

            for (int k = 0; k < 10; k++)
                Console.WriteLine($"Число {k} в дате: {num1[k]}");

            Console.WriteLine("Дата в формате 2: ");
            string time2 = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffzzz");
            int[] num2 = new int[10];
            Console.WriteLine($"{time2}");

            while (i < time2.Length)
            {
                if ((Convert.ToInt32(time2[i]) >= 48) && (Convert.ToInt32(time2[i]) <= 57))
                    num2[Convert.ToInt32(time2[i]) - 48]++;
                i++;
            }

            for (int k = 0; k < 10; k++)
                Console.WriteLine($"Число {k} в дате: {num2[k]}");
            Console.ReadKey();
        }
    }
}
