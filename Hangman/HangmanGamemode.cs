using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class HangmanGamemode
    {
        public string Word { get; set; }
        public StringBuilder GuessedWord = new StringBuilder("");
        public ArrayList WebLines { get; set; } = new ArrayList();
        public int Lives { get; set; } = 8;
        public Boolean GameEnded { get; set; }
        private ArrayList _guesses = new ArrayList();
        private int _turn = 0;

        public HangmanGamemode(string s)
        {
            Console.WriteLine($"Test {s}");
        }

        public HangmanGamemode()
        {
            PrintIntroduction();
            GenerateWord();

            while (!GameEnded)
            {
                WebLines.Clear();
                
                DrawHangman();
                PrintHeader();
                TakeTurn();
                CheckWinLoss();
                
                if(GuessedWord.Equals(Word))
                    EndGame();
            }
        }

        public HangmanGamemode(bool useless)
        {
            PrintIntroduction();
            GenerateWord();
        }
        
        public HangmanGamemode(HangmanGamemode game, Action render)
        {
            Word = game.Word;
            GuessedWord = game.GuessedWord;
            Lives = game.Lives;
            GameEnded = game.GameEnded;
            _guesses = game._guesses;
            _turn = game._turn;

            DrawHangman();
            PrintHeader();
            TakeTurn();
            CheckWinLoss();
                
            if(GuessedWord.Equals(Word))
                EndGame();
            
            render();
        }

        private static void PrintIntroduction()
        {
            Console.WriteLine("Hello! Welcome to le hangman game.\n");
            Console.WriteLine("To play you need to find the hidden word, Take a turn by guessing a letter and once\n" +
                              "the word is found, you win the game. But if you run out of lives, you lose the game.\n");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
        }

        private void EndGame()
        {
            Console.WriteLine("Congratulations! You have won.");
            Console.WriteLine("If you would like to play again type 'Y' if you want to stop type anything else");
            Console.WriteLine("'Y'our choice: ");
            WebLines.Add("Congratulations! You have won.");
            WebLines.Add("If you would like to play again type 'Y' if you want to stop type anything else");
            WebLines.Add("'Y'our choice: ");
            
            string playAgain = Console.ReadLine();

            if (playAgain == null || playAgain.ToLower().Equals("y"))
            {
                GameEnded = true;
                return;
            }
            
            GenerateWord();
        }
        public void GenerateWord()
        {
            string[] lines = System.IO.File.ReadAllLines(".././Hangman/data/words.txt");
            Word = lines[new Random().Next(lines.Length)];
            GuessedWord = new StringBuilder();

            for(int i=0; i<Word.Length; i++)
                GuessedWord.Append('_');
        }
        
        private void DrawHangman()
        {
            Console.Clear();
            string[] lines = System.IO.File.ReadAllLines($".././Hangman/data/hangman_{Lives}.txt");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
                WebLines.Add(line);
            }
                
        }
        
        private void PrintHeader()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Turn: {_turn} || Lives: {Lives} || Current word : {GuessedWord}");
            Console.Write("Current Guesses: ");
            WebLines.Add("----------------------------------");
            WebLines.Add($"Turn: {_turn} || Lives: {Lives} || Current word : {GuessedWord}");
            WebLines.Add("Current Guesses: ");

            foreach (char letter in _guesses)
            {
                Console.Write("{0} ", letter);
            }
        }
        private void TakeTurn()
        {
            Console.Write("\nPlease take a guess: ");
            WebLines.Add("\nPlease take a guess: ");
            string guess = Console.ReadLine();
            new Guess(guess, this);
            _turn++;
        }
        
        public void CheckWinLoss()
        {
            if (Lives == 0)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have lost the Game!");
                Console.WriteLine($"Word = {Word}, Current word = {GuessedWord}");
                WebLines.Add("----------------------------------");
                WebLines.Add("You have lost the Game!");
                WebLines.Add($"Word = {Word}, Current word = {GuessedWord}");
                GameEnded = true;
            }
            else if (GuessedWord.Equals(Word))
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("You have won the game!");
                WebLines.Add("----------------------------------");
                WebLines.Add("You have won the game!");
                //todo change word if game won then change the word and display message
                //todo reset all variables
                GameEnded = true; //todo change this
            }
        }

        public void SetGuesses(ArrayList guesses)
        {
            this._guesses = guesses;
        }

        public ArrayList GetGuesses()
        {
            return _guesses;
        }

        public string GetWord()
        {
            return Word;
        }

        public StringBuilder GetGuessedWord()
        {
            return GuessedWord;
        }

        public void SetGuessedWord(StringBuilder guessedWord)
        {
            this.GuessedWord = guessedWord;
        }

        public void DecreaseLives()
        {
            Lives--;
        }
    }
}