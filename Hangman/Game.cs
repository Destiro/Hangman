using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class Game
    {
        private Word _word = new Word("");
        private int _lives = 8;
        private readonly ArrayList _guesses = new ArrayList(); // todo make generic list
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
            var lines = System.IO.File.ReadAllLines(path);
            _word = new Word(lines[new Random().Next(lines.Length)]);
        }
        
        public void MakeGuess(string guess)
        {
            var makeGuess = new Guess(guess); //todo list of chars

            if (!makeGuess.ValidLength() || !makeGuess.ValidGuess(_guesses)) return;
            var guessChar = char.Parse(guess.ToLower());
            _guesses.Add(guessChar);

            if (!_word.CheckInWord(guessChar))
                DecreaseLives();
        }

        public bool CheckGameEnd()
        {
            return _lives == 0 || HasWon();
        }

        public bool HasWon()
        {
            return _word.GetWord().All(letter => _guesses.Contains(letter));
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