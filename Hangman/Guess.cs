using System;
using System.Collections;
using System.Collections.Generic;
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

        public bool ValidGuess(List<char> guesses)
        {
            var guessChar = char.Parse(_guess.ToLower());
            return !guesses.Contains(guessChar) && char.IsLetter(guessChar);
        }
    }
}