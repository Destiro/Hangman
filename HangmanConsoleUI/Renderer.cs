using System;
using System.Collections;
using System.Linq;

namespace HangmanConsoleUI
{
    public class Renderer
    {
        public static void DrawHangman(int lives)
        {
            Console.Clear();
            string[] lines = System.IO.File.ReadAllLines($"../../.././data/hangman_{lives}.txt");
            foreach (var line in lines)
                Console.WriteLine(line);
        }

        public static void PrintIntroduction()
        {
            Console.Clear();
            Console.WriteLine("Hello! Welcome to le hangman game.\n");
            Console.WriteLine("To play you need to find the hidden word, Take a turn by guessing a letter and once\n" +
                              "the word is found, you win the game. But if you run out of lives, you lose the game.\n");
            Console.WriteLine("Press Enter to continue.");
        }

        public static void PrintHeader(int turn, int lives, string word, ArrayList guesses)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Turn: {turn} || Lives: {lives} || Current word : {CreateGuessedWord(word, guesses)}");
            Console.Write("Current Guesses: ");

            foreach (char letter in guesses)
            {
                Console.Write("{0} ", letter);
            }
        }

        public static void PrintWinLoss(bool hasWon, string word, ArrayList guesses)
        {
            Console.WriteLine("----------------------------------");
            if (!hasWon)
            {
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine($"Word = {word}, Current word = {CreateGuessedWord(word, guesses)}");
            }
            else
            {
                Console.WriteLine("You have won the game!");
            }
        }

        private static string CreateGuessedWord(string word, ArrayList guesses)
        {
            return word.Aggregate("", (current, letter) => current + (guesses.Contains(letter) ? $"{letter}" : "_"));
        }
    }
}