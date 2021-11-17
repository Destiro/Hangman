using System;

namespace Hangman
{
    class Program
    {
        private int lives = 3;
        private String word = "";
        private int gamesWon = 0;
        private Boolean hasLost = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //Console.ReadLine("Please Enter a character");
        }

        public String GenerateWord()
        {
            return "hello"; //todo read from data
        }

        public void TakeTurn()
        {
            //todo a turn for each guess
        }

        public void DrawHangman()
        {
            //todo console log a string of the hangman guy
        }
    }
}