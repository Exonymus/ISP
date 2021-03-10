using System;
using System.Text;

    namespace Task
    {
        class MainClass
        {
            public static void Main(string[] args)
            {
                Console.WriteLine("Ввод строки: ");
                string input;
                input = Console.ReadLine() + " ";

                StringBuilder reverse = new StringBuilder();
                StringBuilder curWord = new StringBuilder();

                for (int i = 0; i < input.Length; i++)
                {
                    if (input[i] != ' ')
                    {
                        curWord.Append(input[i]);
                    }
                    else
                    {
                        curWord.Append(' ');
                        reverse.Insert(0, curWord);
                        curWord.Clear();
                    }
                }
                Console.WriteLine(reverse);
                Console.ReadKey();
            }
        }
    }