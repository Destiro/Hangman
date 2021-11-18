using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintIntroduction();
            new HangmanGamemode();
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("Hello! Welcome to le hangman game.");
            Console.WriteLine("Insert Instructions here. \n"); //todo write instructions
        }
    }
}