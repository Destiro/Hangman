using System;
using Hangman;
using Microsoft.AspNetCore.Mvc;

namespace HangmanWeb
{
    [Route("Game/TakeTurn")]
    public class GameController : ControllerBase
    {
        private readonly Game _game;

        public GameController(Game Game)
        {
            _game = Game;
        }

        [HttpPost]
        public IActionResult Post(string info)
        {
            _game.MakeGuess(Request.Form["takeGuess"]);
            _game.NextTurn();
            
            if (_game.CheckGameEnd() && !_game.HasWon())
                return RedirectToPage("/Game/LoseGame");
            
            if (_game.CheckGameEnd() && _game.HasWon())
                return RedirectToPage("/Game/WinGame");
                
            return RedirectToPage("/Game/TakeTurn");
        }
    }
}