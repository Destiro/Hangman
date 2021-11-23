using System;
using Hangman;

namespace HangmanConsoleUI
{
    class Program
    {
        private static bool PlayAgain = true;

        static void Main(string[] args)
        {
            while (PlayAgain)
            {
                new GameLoop();

                if (!WillPlayAgain())
                     break;
            }
        }

        public static bool WillPlayAgain()
        {
            Console.WriteLine("Would u like to play again? Type 'Y' or 'YES'");
            Console.Write("'Y'our Choice: ");

            var answer = Console.ReadLine()?.ToLower();
            
            return answer == "y" || answer == "yes";
        }
    }
}