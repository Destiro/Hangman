using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangmanWeb.PagesRootDir.Game
{
    public class LoseGame : PageModel
    {
        private Hangman.Game _game;
        public LoseGame(Hangman.Game Game)
        {
            _game = Game;
        }

        public string GetAnswer()
        {
            return _game.GetWord();
        }

        public IActionResult OnPost()
        {
            _game.RestartGame("./data/words.txt");
            return RedirectToPage("/Game/TakeTurn");
        }
    }
}