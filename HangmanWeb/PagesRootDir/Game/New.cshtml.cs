using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace HangmanWeb.PagesRootDir.Game
{
    public class New : PageModel
    {
        private Hangman.Game _game;
        public New(Hangman.Game Game)
        {
            _game = Game;
        }
        
        public IActionResult OnGet()
        {
            _game.RestartGame("./data/words.txt");
            return RedirectToPage("/Game/Play");
        }
    }
}