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
        
        public void OnGet()
        {
            
        }

        public string GetString()
        {
            return _game.Turn.ToString();
        }
    }
}