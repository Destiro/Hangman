using System;
using HangmanConsoleUI;

namespace Hangman
{
    public class GameLoop
    {
        private readonly Game _game;

        public GameLoop()
        {
            _game = new Game();
            Play();
        }

        private void Play()
        {
            Startup();
            
            while (!_game.CheckGameEnd())
            {
                Renderer.DrawHangman(_game.GetLives());
                Renderer.PrintHeader(_game.GetTurn(), _game.GetLives(), _game.GetGuessedWord(), _game.GetGuesses());
                TakeTurn();
            }

            Renderer.PrintWinLoss(_game.HasWon(), _game.GetWord(), _game.GetGuessedWord());
        }

        private void Startup()
        {
            Renderer.PrintIntroduction();
            Console.ReadLine();
            _game.GenerateWord("../../.././data/words.txt");
        }

        private void TakeTurn()
        {
            Console.Write("\nPlease take a guess: ");
            _game.MakeGuess(Console.ReadLine());
            _game.NextTurn();
        }
    }
}