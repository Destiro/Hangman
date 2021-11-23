using System;
using Hangman;

namespace HangmanConsoleUI
{
    public class Renderer
    {
        public Game Game;

        public Renderer(Game game)
        {
            Game = game;
        }

        public void DrawHangman()
        {
            Console.Clear();
            string[] lines = System.IO.File.ReadAllLines($"../../.././data/hangman_{Game.Lives}.txt");
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

        public void PrintHeader() //todo parse in variables
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Turn: {Game.Turn} || Lives: {Game.Lives} || Current word : {Game.GuessedWord}");
            Console.Write("Current Guesses: ");

            foreach (char letter in Game.Guesses)
            {
                Console.Write("{0} ", letter);
            }
        }

        public void PrintWinLoss()
        {
            Console.WriteLine("----------------------------------");
            if (!Game.HasWon())
            {
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine($"Word = {Game.Word}, Current word = {Game.GuessedWord}");
            }
            else
            {
                Console.WriteLine("You have won the game!");
            }
        }
    }
}