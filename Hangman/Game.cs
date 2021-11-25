using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class Game
    {
        private string _word;
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
            _word = lines[new Random().Next(lines.Length)];
            _guessedWord = new StringBuilder();

            for(int i=0; i<_word.Length; i++)
                _guessedWord.Append('_');
        }
        
        public void MakeGuess(string guess)
        {
            var makeGuess = new Guess(guess);
            var currentWord = new Word(_word);//todo set when generated
            
            if (!makeGuess.ValidLength() || !makeGuess.ValidGuess(_guesses)) return;
            var guessChar = char.Parse(guess.ToLower());
            _guesses.Add(guessChar);

            if (currentWord.CheckInWord(guessChar))
            {
                _guessedWord = currentWord.AddGuesses(_guessedWord, guessChar);
            }
            else
            {
                DecreaseLives();
            }
        }

        public bool CheckGameEnd()
        {
            return _lives == 0 || _guessedWord.Equals(_word);
        }

        public bool HasWon()
        {
            return _guessedWord.ToString().Equals(_word);
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
            _word = newWord;
        }

        public ArrayList GetGuesses()
        {
            return _guesses;
        }

        public string GetWord()
        {
            return _word;
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