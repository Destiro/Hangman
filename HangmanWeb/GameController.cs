using System;
using Hangman;
using Microsoft.AspNetCore.Mvc;

namespace HangmanWeb
{
    [Route("game")]
    public class GameController : ControllerBase
    {
        private readonly Game _game;

        public GameController(Game Game)
        {
            _game = Game;
        }
        
        [HttpGet]
        public IActionResult SetupGame()
        {
            return Ok("Im in a game");
        }
        
        [HttpGet]
        public void TakeGuess()
        {
            
        }

        [HttpGet]
        public IActionResult TakeTurn()
        {
            return Ok("Hello");
        }
        
        [HttpPost]
        public IActionResult TakeTurn(string info)
        {
            Console.WriteLine(info);
            //_game.makeguess()
            Redirect("/Game/TakeTurn");
            return Ok("Hello");
        }
    }
}