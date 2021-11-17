using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    class Program
    {
        private static int lives = 8;
        private static string word = "";
        private static StringBuilder guessedWord = new StringBuilder("");
        private static Boolean hasLost = false;
        private static ArrayList guesses = new ArrayList();
        private static int turn = 0;
        //private static int gamesWon = 0;

        static void Main(string[] args)
        {
            PrintIntroduction();
            GenerateWord();

            while (!hasLost)
            {
                DrawHangman();
                TakeTurn();
                CheckWinLoss();
            }
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("Hello! Welcome to le hangman game.");
            Console.WriteLine("Insert Instructions here. \n"); //todo write instructions
        }

        private static void GenerateWord()
        {
            word = "rhythm"; //todo read from data
            guessedWord = new StringBuilder("______");
        }
        
        private static void DrawHangman()
        {
            //todo console log a string of the hangman guy from file using mods
        }

        private static void TakeTurn()
        {
            Console.WriteLine("----------------------------------");
            
            Console.WriteLine($"Turn: {turn} || Lives: "+lives+" || Current word : "+guessedWord);
            Console.Write("Current Guesses: ");

            foreach (char letter in guesses)
            {
                Console.Write("{0} ", letter);
            }

            Console.Write("\nPlease take a guess: ");
            var guess = Console.ReadLine();
            if (guess is {Length: 1})
            {
                CheckGuess(char.Parse(guess)); 
            }
            else
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Invalid Guess! Please enter 1 character.");
            }
            
            
        }

        private static void CheckGuess(char guess)
        {
            if (guesses.Contains(guess))
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have already guessed this letter!");
                return;
            } 
            else
            {
                guesses.Add(guess);
                if (word.Contains(guess))
                {
                    for (var i = 0; i < word.Length; i++)
                    {
                        if (word[i].Equals(guess))
                            guessedWord[i] = guess;
                    }
                }
                else
                {
                    lives--;
                }
            }
        }

        private static void CheckWinLoss()
        {
            if (lives == 0)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine("Word = "+word+", Current word = "+guessedWord);
                hasLost = true;
            }
            else if(guessedWord.Equals(word))
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have won the game!");
                //todo change word if game won then change the word and display message
                //todo reset all variables
                hasLost = true; //todo change thisx
            }
            
        }
    }
}