using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class HangmanGamemode
    {
        public string Word { get; set; }
        public StringBuilder guessedWord = new StringBuilder("");
        public int lives { get; set; } = 8;
        public Boolean gameEnded { get; set; }
        private ArrayList guesses = new ArrayList();
        private int turn = 0;

        public HangmanGamemode(string s)
        {
            Console.WriteLine($"Test {s}");
        }

        public HangmanGamemode()
        {
            GenerateWord();
            
            while (!gameEnded)
            {
                if(guessedWord.Equals(Word))
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
                gameEnded = true;
                return;
            }
            
            GenerateWord();
        }
        public void GenerateWord()
        {
            string[] lines = System.IO.File.ReadAllLines("../../.././data/words.txt");
            Word = lines[new Random().Next(lines.Length)];
            guessedWord = new StringBuilder();

            for(int i=0; i<Word.Length; i++)
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
        
        public void CheckWinLoss()
        {
            if (lives == 0)
            {
                //DrawHangman();
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine($"Word = {Word}, Current word = {guessedWord}");
                gameEnded = true;
            }
            else if (guessedWord.Equals(Word))
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have won the game!");
                //todo change word if game won then change the word and display message
                //todo reset all variables
                gameEnded = true; //todo change this
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
            return Word;
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