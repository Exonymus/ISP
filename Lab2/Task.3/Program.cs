using System;

namespace Task
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            string line = "ugrqhwuhngdxkvfikpYhhonfbGjutia" +
                "xurqahfiubiywkvacntdeuGmgsmpcnznefg" +
                "cseebQhcfyqrufeghaevdufjhuqfgbvtqeshyjsyxrun" +
                "qbrjxgsnzkcinuwgpSveDwaqnwixigylzrtgcgiaihtgbj" +
                "udmlivvpkGabvaQuftmqivbqditvwSdupdcelwLcqkhzAblh" +
                "bncatkbybwhCbatoqflsytjivjayocjcDmuiscbecdcpoFaqqsia"; //256 symbols

            int num = rnd.Next(1000000000, 2000000000);
            int choice = 0;
            bool changed = false;

            for (int i = 0; i < 30; i++)
            {
                while (!changed)
                {
                    if ((num % 1000) < 256)
                    {
                        choice = num % 1000;
                        changed = true;
                        num -= 256;
                    }
                    else
                        num -= 100;  
                }

                changed = false;
                Console.Write(line[choice]);
            }
            Console.ReadKey();
        }
    }
}
