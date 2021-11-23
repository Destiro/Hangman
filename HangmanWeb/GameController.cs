using Hangman;
using Microsoft.AspNetCore.Mvc;

namespace HangmanWeb
{
    [Route("game")]
    public class GameController : ControllerBase
    {
        private Game _game;
        GameController(Game game)
        {
            _game = game;
        }
        
        [HttpGet]
        public IActionResult Game()
        {
            return Ok(_game.Word);
            return Ok("Hello Word!");
        }
    }
}