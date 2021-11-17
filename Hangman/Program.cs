using System;

namespace Hangman
{
    class Program
    {
        private static int lives = 3;
        private static String word = "";
        private static int gamesWon = 0;
        private static Boolean hasLost = false;

        static void Main(string[] args)
        {
            PrintIntroduction();
            GenerateWord();
            
            while (!hasLost)
            {
                DrawHangman();
                TakeTurn();
                CheckGameWin();
            }
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("Hello! Welcome to le hangman game.");
            Console.WriteLine("Insert Instructions here.");
        }

        private static String GenerateWord()
        {
            return "hello"; //todo read from data
        }
        
        /* Example:
        .............______
        .............|....|
        .............O....|
        ............/|\...|
        ............/.\...|
        ................./|
        ..........=========
         */
        private static void DrawHangman()
        {
            
            //todo console log a string of the hangman guy
        }

        private static void TakeTurn()
        {
            //todo a turn for each guess
            //Console.ReadLine("Please Enter a character");
        }

        private static void CheckGameWin()
        {
            //todo change word if game won then change the word and display message
        }
    }
}