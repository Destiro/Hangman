using System;
using System.Collections;
using System.Text;
using Hangman;

namespace HangmanConsoleUI
{
    public class Renderer
    {
        public static void DrawHangman(int Lives)
        {
            Console.Clear();
            string[] lines = System.IO.File.ReadAllLines($"../../.././data/hangman_{Lives}.txt");
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

        public static void PrintHeader(int Turn, int Lives, StringBuilder GuessedWord, ArrayList Guesses)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Turn: {Turn} || Lives: {Lives} || Current word : {GuessedWord}");
            Console.Write("Current Guesses: ");

            foreach (char letter in Guesses)
            {
                Console.Write("{0} ", letter);
            }
        }

        public static void PrintWinLoss(bool HasWon, string Word, StringBuilder GuessedWord)
        {
            Console.WriteLine("----------------------------------");
            if (!HasWon)
            {
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine($"Word = {Word}, Current word = {GuessedWord}");
            }
            else
            {
                Console.WriteLine("You have won the game!");
            }
        }
    }
}