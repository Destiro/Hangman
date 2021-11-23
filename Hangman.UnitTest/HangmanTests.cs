using System;
using System.Text;
using Xunit;
using Hangman;
using Xunit.Abstractions;


namespace HangmanTests
{
    public class HangmanTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public HangmanTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private Game CreateTestGame(string word)
        {
            Game hmgmode = new Game();
            hmgmode.Word = word;
            for (int i = 0; i < hmgmode.Word.Length; i++)
                hmgmode.GuessedWord.Append('_');

            return hmgmode;
        }

        [Fact]
        public void InitializeEmptyGameCorrectlyTest()
        {
            Game hmgmode = new Game();
            Assert.Empty(hmgmode.Guesses);
            Assert.True(hmgmode.Turn == 0);
            Assert.True(hmgmode.Lives == 8);
            Assert.Null(hmgmode.Word);
            Assert.True(hmgmode.GuessedWord.ToString().Equals(""));
        }

        [Fact]
        public void AbleToIncrementTurn()
        {
            Game hmgmode = new Game();
            Assert.True(hmgmode.Turn == 0);

            hmgmode.NextTurn();
            Assert.True(hmgmode.Turn == 1);
        }

        [Fact]
        public void CheckEndWithoutEndingGame()
        {
            Game hmgmode = CreateTestGame("abc");
            Assert.False(hmgmode.CheckGameEnd());
        }

        [Fact]
        public void CheckGameCanWin()
        {
            Game hmgmode = CreateTestGame("abc");
            Assert.False(hmgmode.CheckGameEnd());
            Assert.False(hmgmode.HasWon());
            hmgmode.GuessedWord = new StringBuilder(hmgmode.Word);
            Assert.True(hmgmode.CheckGameEnd());
            Assert.True(hmgmode.HasWon());
        }

        [Fact]
        public void WordGeneratedTest()
        {
            Game hmgmode = new Game();
            Assert.Null(hmgmode.GetWord());
            Assert.Equal("", hmgmode.GetGuessedWord().ToString());

            hmgmode.GenerateWord();
            Assert.NotNull(hmgmode.GetWord());
            Assert.True(hmgmode.GetWord().Length > 0);
        }

        [Fact]
        public void ValidGuessInWord()
        {
            Game hmgmode = CreateTestGame("abc");

            Assert.Empty(hmgmode.GetGuesses());
            Assert.Equal("___", hmgmode.GuessedWord.ToString());

            new Guess("a", hmgmode);
            Assert.NotEmpty(hmgmode.GetGuesses());
            Assert.Equal("a__", hmgmode.GuessedWord.ToString());
        }

        [Fact]
        public void ValidGuessNotInWord()
        {
            Game hmgmode = CreateTestGame("abc");

            Assert.Empty(hmgmode.GetGuesses());
            Assert.Equal("___", hmgmode.GuessedWord.ToString());

            new Guess("d", hmgmode);
            Assert.NotEmpty(hmgmode.GetGuesses());
            Assert.Equal("___", hmgmode.GuessedWord.ToString());
        }

        [Fact]
        public void DuplicateGuessTest()
        {
            Game hmgmode = new Game();
            hmgmode.Word = "hello";
            Assert.Empty(hmgmode.GetGuesses());

            new Guess("a", hmgmode);
            Assert.True(1 == hmgmode.GetGuesses().Count);

            new Guess("a", hmgmode);
            Assert.True(1 == hmgmode.GetGuesses().Count);
        }

        [Fact]
        public void UserCanWinTest()
        {
            Game hmgmode = CreateTestGame("hello");
            Assert.False(hmgmode.CheckGameEnd());

            new Guess("h", hmgmode);
            Assert.False(hmgmode.CheckGameEnd());

            new Guess("e", hmgmode);
            Assert.False(hmgmode.CheckGameEnd());

            new Guess("l", hmgmode);
            Assert.False(hmgmode.CheckGameEnd());

            new Guess("o", hmgmode);
            Assert.True(hmgmode.CheckGameEnd());
        }

        [Fact]
        public void CheckGameCanLose()
        {
            Game hmgmode = CreateTestGame("l");
            Assert.False(hmgmode.CheckGameEnd());

            hmgmode.Lives = 0;
            Assert.True(hmgmode.CheckGameEnd());
            Assert.False(hmgmode.HasWon());
        }

        [Fact]
        public void DoubleUpLetterTest()
        {
            Game hmgmode = CreateTestGame("abcabcab");

            new Guess("c", hmgmode);
            Assert.Equal("__c__c__", hmgmode.GetGuessedWord().ToString());

            new Guess("a", hmgmode);
            Assert.Equal("a_ca_ca_", hmgmode.GetGuessedWord().ToString());
        }

        [Fact]
        public void DecreasesLivesTest()
        {
            Game hmgmode = CreateTestGame("a");

            Assert.Equal(8, hmgmode.Lives);

            hmgmode.DecreaseLives();
            Assert.Equal(7, hmgmode.Lives);

            new Guess("b", hmgmode);
            Assert.Equal(6, hmgmode.Lives);
        }

        [Fact]
        public void UserCanLoseTest()
        {
            Game hmgmode = CreateTestGame("a");
            string makeGuesses = "bcdefghijk";
            for (int i = 0; i < 8; i++)
                new Guess(makeGuesses[i].ToString(), hmgmode);

            Assert.True(hmgmode.CheckGameEnd());
        }

        [Fact]
        public void UserCanGuessDifferentCasings()
        {
            Game hmgmode = CreateTestGame("a");

            new Guess("b", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('b'));

            new Guess("C", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('c'));

            int currLives = hmgmode.Lives;

            new Guess("c", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('c'));
            Assert.True(hmgmode.Lives == currLives);
        }


        [Fact]
        public void UserCannotGuessANonAlphabetChar()
        {
            Game hmgmode = CreateTestGame("a");
            Assert.Empty(hmgmode.GetGuesses());

            new Guess("%", hmgmode);
            Assert.Empty(hmgmode.GetGuesses());
        }

        [Fact]
        public void UserCannotGuessMultipleChars()
        {
            Game hmgmode = CreateTestGame("a");
            Assert.Empty(hmgmode.GetGuesses());

            new Guess("multiple chars", hmgmode);
            Assert.Empty(hmgmode.GetGuesses());
        }
    }
}