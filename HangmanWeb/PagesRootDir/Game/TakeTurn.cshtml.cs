using System;
using Microsoft.AspNetCore.Mvc;
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
            string readableWord = "";
            foreach (var letter in _game.GuessedWord.ToString())
                readableWord += letter + " ";
            
            return readableWord;
        }
        
        public string GetGuesses()
        {
            var guesses = "";
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
        public IActionResult OnPost()
        {
            _game.MakeGuess(Request.Form["takeGuess"]);
            _game.NextTurn();
            
            if (_game.CheckGameEnd() && !_game.HasWon())
                return RedirectToPage("/Game/LoseGame");
            
            if (_game.CheckGameEnd() && _game.HasWon())
                return RedirectToPage("/Game/WinGame");
            
            return Page();
        }
    }
}