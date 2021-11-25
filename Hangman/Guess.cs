using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class Guess
    {
        private static string _guess;
        public Guess(string guess)
        {
            _guess = guess;
        }

        public bool ValidLength()
        {
            return _guess != null && _guess.Length == 1;
        }

        public bool ValidGuess(ArrayList guesses)
        {
            var guessChar = char.Parse(_guess.ToLower());
            return !guesses.Contains(guessChar) && char.IsLetter(guessChar);
        }
    }
}