using System;
using System.Collections;
using System.Text;

namespace Hangman
{
    public class Guess
    {
        private ArrayList guesses;
        private string word;
        private StringBuilder guessedWord;
        private Game Game;
        public Guess(string guess, Game game)
        {
            guessedWord = game.GetGuessedWord();
            guesses = game.GetGuesses();
            word = game.GetWord();
            Game = game;

            if (ValidLength(guess) && ValidGuess(char.Parse(guess.ToLower())))
            {
                var guessChar = char.Parse(guess.ToLower());
                guesses.Add(guessChar);
                Game.SetGuesses(guesses);
                
                if (CheckInWord(guessChar))
                {
                    game.SetGuessedWord(guessedWord);
                }
                else
                {
                    game.DecreaseLives();
                }
            }
        }

        public bool ValidLength(string guess)
        {
            return guess != null && guess.Length == 1;
        }

        private bool ValidGuess(char guess)
        {
            return !Game.GetGuesses().Contains(guess) && char.IsLetter(guess);
        }

        private bool CheckInWord(char guess)
        {
            Boolean addedLetter = false;
            
            for (var i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(guess))
                {
                    guessedWord[i] = guess;
                    addedLetter = true;
                }
            }

            return addedLetter;
        }
    }
}