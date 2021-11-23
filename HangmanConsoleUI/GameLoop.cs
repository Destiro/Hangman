using System;
using HangmanConsoleUI;

namespace Hangman
{
    public class GameLoop
    {
        public Game Game;
        public Renderer Renderer;

        public GameLoop()
        {
            Game = new Game();
            Renderer = new Renderer(Game);
            Renderer.PrintIntroduction();
            Console.ReadLine();
            Game.GenerateWord();
            Play();
        }

        private void Play()
        {
            while (!Game.CheckGameEnd())
            {
                Renderer.DrawHangman();
                Renderer.PrintHeader();
                TakeTurn();
            }

            Renderer.PrintWinLoss();
        }

        private void TakeTurn()
        {
            Console.Write("\nPlease take a guess: ");
            new Guess(Console.ReadLine(), Game);
            Game.NextTurn();
        }
    }
}