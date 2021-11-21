using System;

/*using Microsoft.AspNetCore.Html;
using static System.Console;
using static System.Text.Encodings.Web.HtmlEncoder;
*/

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var builder = new HtmlContentBuilder();
            builder.AppendFormat("<html><h1>{0}</h1></html>", "Hello World!");
            builder.WriteTo(Out, Default);*/
            
            PrintIntroduction();
            new HangmanGamemode();
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("Hello! Welcome to le hangman game.\n");
            Console.WriteLine("To play you need to find the hidden word, Take a turn by guessing a letter and once\n" +
                              "the word is found, you win the game. But if you run out of lives, you lose the game.\n");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }
    }
}