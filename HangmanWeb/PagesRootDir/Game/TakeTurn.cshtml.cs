using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangmanWeb.PagesRootDir.Game
{
    public class TakeTurn : PageModel
    {
        private readonly Hangman.Game _game;

        public TakeTurn(Hangman.Game Game)
        {
            _game = Game;
        }

        public string GetTurn()
        {
            return _game.Turn.ToString();
        }
        
        public string GetLives()
        {
            return _game.Lives.ToString();
        }
        
        public string GetGuessedWord()
        {
            return _game.GuessedWord.ToString();
        }
        
        public string GetGuesses()
        {
            string guesses = "";
            foreach(var guess in _game.Guesses)
            {
                guesses += guess + " ";
            }
            
            return guesses;
        }
        public string GetDrawingUrl()
        {
            return "https://raw.githubusercontent.com/Destiro/Hangman/add-to-web/HangmanWeb/data/drawings/hangman_" +
                   _game.Lives + ".png";
        }
    }
}