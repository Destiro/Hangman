using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class HangmanGamemode
    {
        private string word;
        private StringBuilder guessedWord = new StringBuilder("");
        private int lives = 8;
        private Boolean hasLost = false;
        private ArrayList guesses = new ArrayList();
        private int turn = 0;

        public HangmanGamemode(string s)
        {
            Console.WriteLine($"Test {s}");
        }

        public HangmanGamemode()
        {
            GenerateWord();
            
            while (!hasLost)
            {
                if(guessedWord.Equals(word))
                    EndGame();
                
                DrawHangman();
                PrintHeader();
                TakeTurn();
                CheckWinLoss();
            }
        }

        private void EndGame()
        {
            Console.WriteLine("Congratulations! You have won.");
            Console.WriteLine("If you would like to play again type 'Y' if you want to stop type anything else");
            Console.WriteLine("'Y'our choice: ");
            string playAgain = Console.ReadLine();

            if (playAgain == null || playAgain.ToLower().Equals("y"))
            {
                hasLost = true;
                return;
            }
            
            GenerateWord();
        }
        public void GenerateWord()
        {
            string[] lines = System.IO.File.ReadAllLines("../../.././data/words.txt");
            word = lines[new Random().Next(lines.Length)];
            guessedWord = new StringBuilder();

            for(int i=0; i<word.Length; i++)
                guessedWord.Append('_');
        }
        
        private void DrawHangman()
        {
            Console.Clear();
            string[] lines = System.IO.File.ReadAllLines($"../../.././data/hangman_{lives}.txt");
            foreach (var line in lines)
                Console.WriteLine(line);
        }
        
        private void PrintHeader()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Turn: {turn} || Lives: {lives} || Current word : {guessedWord}");
            Console.Write("Current Guesses: ");

            foreach (char letter in guesses)
            {
                Console.Write("{0} ", letter);
            }
        }
        private void TakeTurn()
        {
            Console.Write("\nPlease take a guess: ");
            string guess = Console.ReadLine();
            new Guess(guess, this);
            turn++;
        }
        
        private void CheckWinLoss()
        {
            if (lives == 0)
            {
                DrawHangman();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine($"Word = {word}, Current word = {guessedWord}");
                hasLost = true;
            }
            else if (guessedWord.Equals(word))
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have won the game!");
                //todo change word if game won then change the word and display message
                //todo reset all variables
                hasLost = true; //todo change this
            }
        }

        public void SetGuesses(ArrayList guesses)
        {
            this.guesses = guesses;
        }

        public ArrayList GetGuesses()
        {
            return guesses;
        }

        public string GetWord()
        {
            return word;
        }

        public StringBuilder GetGuessedWord()
        {
            return guessedWord;
        }

        public void SetGuessedWord(StringBuilder guessedWord)
        {
            this.guessedWord = guessedWord;
        }

        public void DecreaseLives()
        {
            lives--;
        }
    }
}