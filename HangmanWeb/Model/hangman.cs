using System;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HangmanWeb.Model
{
    public class Hangman
    {
        private readonly Hangman.Game _game;

        public TakeTurn(Hangman.Game Game)
        {
            _game = Game;
        }
        
        public void OnGet()
        {
            Console.WriteLine("get methpod");

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
            return _game.GuessedWord.ToString();
        }
        
        public string GetGuesses()
        {
            string guesses = "";
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

        public void TurnLogic()
        {
            
        }
    
        public PageResult OnPost()
        {
            Console.WriteLine("post methpod");
            var guess = Request.Form["takeGuess"];
            Console.WriteLine($"Guess taken: {guess}");
            _game.DecreaseLives();
            _game.NextTurn();
            return Page();
        }
    }
}