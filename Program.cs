namespace Slot_Machine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в казино! Здесь надежда умирает, как последний взгляд перед финалом.");

            while (true)
            {
                int bet = RequestBet();
                int num1 = GenerateRandomNumber();
                int num2 = GenerateRandomNumber();
                int num3 = GenerateRandomNumber();

                ShowSpinningEffect();
                PrintCombination(num1, num2, num3);

                double winnings = CalculateWinnings(bet, num1, num2, num3);
                PrintResult(winnings);

                Console.WriteLine("Хотите сыграть снова? (да/нет)");
                string answer = Console.ReadLine();
                if (answer.ToLower() != "да")
                {
                    Console.WriteLine("Спасибо за игру! До свидания!");
                    break;
                }
            }
        }

        static int RequestBet()
        {
            int bet;
            while (true)
            {
                Console.Write("Введите размер ставки (от 5$ до 100$, шаг ставки 5$): ");
                if (int.TryParse(Console.ReadLine(), out bet) && bet >= 5 && bet <= 100 && bet % 5 == 0)
                {
                    break;
                }
                Console.WriteLine("Неверный ввод! Введите число от 5 до 100, кратное 5.");
            }
            return bet;
        }

        static int GenerateRandomNumber()
        {
            Random rnd = new Random();
            return rnd.Next(1, 10);
        }

        static void ShowSpinningEffect()
        {
            Console.Write("Спиннинг");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }
            Console.WriteLine();
        }

        static void PrintCombination(int num1, int num2, int num3)
        {
            Console.WriteLine($"Выпала комбинация: {num1} {num2} {num3}");
        }

        static double CalculateWinnings(int bet, int num1, int num2, int num3)
        {
            double multiplier = 0;
            if (num1 == num2 && num2 == num3)
            {
                if (num1 == 1) multiplier = 15;
                else if (num1 == 2) multiplier = 30;
                else if (num1 == 3) multiplier = 45;
                else if (num1 == 4) multiplier = 60;
                else if (num1 == 5) multiplier = 75;
                else if (num1 == 6) multiplier = 90;
                else if (num1 == 7) multiplier = 225;
                else if (num1 == 8) multiplier = 120;
                else if (num1 == 9) multiplier = 135;
            }
            else if (num1 == num2 || num1 == num3 || num2 == num3)
            {
                if (num1 == 1 || num2 == 1 || num3 == 1) multiplier = 1.25;
                else if (num1 == 2 || num2 == 2 || num3 == 2) multiplier = 2.5;
                else if (num1 == 3 || num2 == 3 || num3 == 3) multiplier = 3.75;
                else if (num1 == 4 || num2 == 4 || num3 == 4) multiplier = 5;
                else if (num1 == 5 || num2 == 5 || num3 == 5) multiplier = 6.25;
                else if (num1 == 6 || num2 == 6 || num3 == 6) multiplier = 7.5;
                else if (num1 == 7 || num2 == 7 || num3 == 7) multiplier = 18.75;
                else if (num1 == 8 || num2 == 8 || num3 == 8) multiplier = 10;
                else if (num1 == 9 || num2 == 9 || num3 == 9) multiplier = 11.25;
            }
            else if (num1 == 7 || num2 == 7 || num3 == 7)
            {
                multiplier = 2;
            }
            else if (num1 == 9 || num2 == 9 || num3 == 9)
            {
                multiplier = 1.5;
            }
            return bet * multiplier;
        }

        static void PrintResult(double winnings)
        {
            if (winnings > 0)
            {
                Console.WriteLine($"Поздравляем! Вы выиграли {winnings}$");
            }
            else
            {
                Console.WriteLine("К сожалению, вы проиграли.");
            }
        }
    }
}
