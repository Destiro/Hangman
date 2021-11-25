using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangmanWeb.PagesRootDir.Game
{
    public class WinGame : PageModel
    {
        private Hangman.Game _game;
        public WinGame(Hangman.Game Game)
        {
            _game = Game;
        }

        public string GetAnswer()
        {
            return _game.GetWord();
        }

        public IActionResult OnPost()
        {
            _game.RestartGame();
            return RedirectToPage("/Game/TakeTurn");
        }
    }
}