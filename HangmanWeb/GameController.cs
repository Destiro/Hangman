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
        
        // public IActionResult SetupGame()
        // {
        //     return Ok("Im in a game");
        // }
        //
        // [HttpGet]
        // public void TakeGuess()
        // {
        //     
        // }

        // [HttpGet]
        // public IActionResult TakeTurn()
        // {
        //     //return ViewComponent();
        // }
        
        [HttpPost]
        public IActionResult Post(string info)
        {
            Console.WriteLine(info);
            Console.WriteLine("controller taketurn");
            //_game.makeguess()
            //RedirectToRoute()
            _game.DecreaseLives();
            return RedirectToPage("/Game/TakeTurn");
        }
    }
}