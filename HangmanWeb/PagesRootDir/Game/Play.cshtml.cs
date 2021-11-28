using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangmanWeb.PagesRootDir.Game
{
    public class TakeTurn : PageModel
    {
        private readonly Hangman.Game _game;

        public TakeTurn(Hangman.Game game)
        {
            _game = game;
        }

        public string GetTurn()
        {
            return _game.GetTurn().ToString();
        }
        
        public string GetLives()
        {
            return _game.GetLives().ToString();
        }
        
        public string GetGuessedWord()
        {
            return _game.GetWord().Aggregate("", (current, letter) => current + (_game.GetGuesses().Contains(letter) ? $"{letter} " : "_ "));
        }
        
        public string GetGuesses()
        {
            return _game.GetGuesses().Cast<object?>().Aggregate("", (current, guess) => current + (guess + " "));
        }

        public string GetDrawingUrl()
        {
            return $"https://raw.githubusercontent.com/Destiro/Hangman/add-to-web/HangmanWeb/data/drawings/hangman_{_game.GetLives()}.png";
        }
        public IActionResult OnPost()
        {
            _game.MakeGuess(Request.Form["takeGuess"]);
            _game.NextTurn();
            return GetRedirect();
        }

        private IActionResult GetRedirect()
        {
            if (_game.CheckGameEnd())
                return _game.HasWon() ? RedirectToPage("/Game/WinGame") : RedirectToPage("/Game/LoseGame");

            return Page();
        }
    }
}