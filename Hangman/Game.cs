using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class Game
    {
        public string Word { get; set; }
        public StringBuilder GuessedWord = new StringBuilder("");
        public int Lives { get; set; } = 8;
        public ArrayList Guesses = new ArrayList();
        public int Turn;
        public void GenerateWord()
        {
            string[] lines = System.IO.File.ReadAllLines("../../.././data/words.txt");
            Word = lines[new Random().Next(lines.Length)];
            GuessedWord = new StringBuilder();

            for(int i=0; i<Word.Length; i++)
                GuessedWord.Append('_');
        }

        public bool CheckGameEnd()
        {
            return Lives == 0 || GuessedWord.Equals(Word);
        }

        public bool HasWon()
        {
            return GuessedWord.ToString().Equals(Word);
        }

        public void SetGuesses(ArrayList guesses)
        {
            Guesses = guesses;
        }

        public ArrayList GetGuesses()
        {
            return Guesses;
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
            GuessedWord = guessedWord;
        }

        public void DecreaseLives()
        {
            Lives--;
        }

        public void NextTurn()
        {
            Turn++;
        }
    }
}