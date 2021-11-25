using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class Game
    {
        private Word _word = new Word("");
        private StringBuilder _guessedWord = new StringBuilder("");
        private int _lives = 8;
        private readonly ArrayList _guesses = new ArrayList();
        private int _turn;

        public void RestartGame(string path)
        {
            GenerateWord(path);
            _guesses.Clear();
            _turn = 0;
            _lives = 8;
        }
        public void GenerateWord(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);
            _word = new Word(lines[new Random().Next(lines.Length)]);
            _guessedWord = new StringBuilder();

            for(int i=0; i<_word.GetWord().Length; i++)
                _guessedWord.Append('_');
        }
        
        public void MakeGuess(string guess)
        {
            var makeGuess = new Guess(guess);

            if (!makeGuess.ValidLength() || !makeGuess.ValidGuess(_guesses)) return;
            var guessChar = char.Parse(guess.ToLower());
            _guesses.Add(guessChar);

            if (_word.CheckInWord(guessChar))
            {
                _guessedWord = _word.AddGuesses(_guessedWord, guessChar);
            }
            else
            {
                DecreaseLives();
            }
        }

        public bool CheckGameEnd()
        {
            return _lives == 0 || _guessedWord.Equals(GetWord());
        }

        public bool HasWon()
        {
            return _guessedWord.ToString().Equals(GetWord());
        }
        
        public void SetGuessedWord(StringBuilder newGuessedWord)
        {
            _guessedWord = newGuessedWord;
        }

        public void SetLives(int newLives)
        {
            _lives = newLives;
        }

        public void SetWord(string newWord)
        {
            _word = new Word(newWord);
        }

        public ArrayList GetGuesses()
        {
            return _guesses;
        }

        public string GetWord()
        {
            return _word.GetWord();
        }

        public int GetTurn()
        {
            return _turn;
        }

        public StringBuilder GetGuessedWord()
        {
            return _guessedWord;
        }

        public void DecreaseLives()
        {
            _lives--;
        }

        public void NextTurn()
        {
            _turn++;
        }

        public int GetLives()
        {
            return _lives;
        }
    }
}