using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    public class Guess
    {
        public static bool ValidLength(string guess)
        {
            return guess != null && guess.Length == 1;
        }

        public static bool ValidGuess(string guess, List<char> guesses)
        {
            var guessChar = char.Parse(guess.ToLower());
            return !guesses.Contains(guessChar) && char.IsLetter(guessChar);
        }
    }
}