using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class Guess
    {
        public Guess(string guess, HangmanGamemode hangmanGamemode)
        {
            guess = guess?.ToLower();
            if (guess != null && guess.Length == 1)
                CheckGuess(char.Parse(guess), hangmanGamemode);
        }

        private void CheckGuess(char guess, HangmanGamemode hangmanGamemode)
        {
            ArrayList guesses = hangmanGamemode.GetGuesses();
            string word = hangmanGamemode.GetWord();
            Boolean addedLetter = false;
            StringBuilder guessedWord = hangmanGamemode.GetGuessedWord();

            if (hangmanGamemode.GetGuesses().Contains(guess) || !Char.IsLetter(guess))
                return;

            guesses.Add(guess);
            hangmanGamemode.SetGuesses(guesses);

            for (var i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(guess))
                {
                    guessedWord[i] = guess;
                    addedLetter = true;
                }
            }

            if (addedLetter)
            {
                hangmanGamemode.SetGuessedWord(guessedWord);
            }
            else
            {
                hangmanGamemode.DecreaseLives();
            }
        }
    }
}