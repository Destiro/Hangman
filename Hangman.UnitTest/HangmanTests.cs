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
            hmgmode.SetWord(word);

            StringBuilder newGuessedWord = new StringBuilder("");
            for (int i = 0; i < word.Length; i++)
                newGuessedWord.Append('_');
            hmgmode.SetGuessedWord(newGuessedWord);

            return hmgmode;
        }

        [Fact]
        public void InitializeEmptyGameCorrectlyTest()
        {
            Game hmgmode = new Game();
            Assert.Empty(hmgmode.GetGuesses());
            Assert.True(hmgmode.GetTurn() == 0);
            Assert.True(hmgmode.GetLives() == 8);
            Assert.Equal("", hmgmode.GetWord());
            Assert.True(hmgmode.GetGuessedWord().ToString().Equals(""));
        }

        [Fact]
        public void AbleToIncrementTurn()
        {
            Game hmgmode = new Game();
            Assert.True(hmgmode.GetTurn() == 0);

            hmgmode.NextTurn();
            Assert.True(hmgmode.GetTurn() == 1);
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
            hmgmode.SetGuessedWord(new StringBuilder(hmgmode.GetWord()));
            Assert.True(hmgmode.CheckGameEnd());
            Assert.True(hmgmode.HasWon());
        }

        [Fact]
        public void WordGeneratedTest()
        {
            Game hmgmode = new Game();
            Assert.Equal("",hmgmode.GetWord());
            Assert.Equal("", hmgmode.GetGuessedWord().ToString());

            hmgmode.GenerateWord("../../.././data/words.txt");
            Assert.NotNull(hmgmode.GetWord());
            Assert.True(hmgmode.GetWord().Length > 0);
        }

        [Fact]
        public void ValidGuessInWord()
        {
            Game hmgmode = CreateTestGame("abc");

            Assert.Empty(hmgmode.GetGuesses());
            Assert.Equal("___", hmgmode.GetGuessedWord().ToString());
            
            hmgmode.MakeGuess("a");
            Assert.NotEmpty(hmgmode.GetGuesses());
            Assert.Equal("a__", hmgmode.GetGuessedWord().ToString());
        }

        [Fact]
        public void ValidGuessNotInWord()
        {
            Game hmgmode = CreateTestGame("abc");

            Assert.Empty(hmgmode.GetGuesses());
            Assert.Equal("___", hmgmode.GetGuessedWord().ToString());

            hmgmode.MakeGuess("d");
            Assert.NotEmpty(hmgmode.GetGuesses());
            Assert.Equal("___", hmgmode.GetGuessedWord().ToString());
        }

        [Fact]
        public void DuplicateGuessTest()
        {
            Game hmgmode = new Game();
            hmgmode.SetWord("hello");
            Assert.Empty(hmgmode.GetGuesses());

            hmgmode.MakeGuess("a");
            Assert.True(1 == hmgmode.GetGuesses().Count);

            hmgmode.MakeGuess("a");
            Assert.True(1 == hmgmode.GetGuesses().Count);
        }

        [Fact]
        public void UserCanWinTest()
        {
            Game hmgmode = CreateTestGame("hello");
            Assert.False(hmgmode.CheckGameEnd());

            hmgmode.MakeGuess("h");
            Assert.False(hmgmode.CheckGameEnd());

            hmgmode.MakeGuess("e");
            Assert.False(hmgmode.CheckGameEnd());

            hmgmode.MakeGuess("l");
            Assert.False(hmgmode.CheckGameEnd());

            hmgmode.MakeGuess("o");
            Assert.True(hmgmode.CheckGameEnd());
        }

        [Fact]
        public void CheckGameCanLose()
        {
            Game hmgmode = CreateTestGame("l");
            Assert.False(hmgmode.CheckGameEnd());

            hmgmode.SetLives(0);
            Assert.True(hmgmode.CheckGameEnd());
            Assert.False(hmgmode.HasWon());
        }

        [Fact]
        public void DoubleUpLetterTest()
        {
            Game hmgmode = CreateTestGame("abcabcab");

            hmgmode.MakeGuess("c");
            Assert.Equal("__c__c__", hmgmode.GetGuessedWord().ToString());

            hmgmode.MakeGuess("a");
            Assert.Equal("a_ca_ca_", hmgmode.GetGuessedWord().ToString());
        }

        [Fact]
        public void DecreasesLivesTest()
        {
            Game hmgmode = CreateTestGame("a");

            Assert.Equal(8, hmgmode.GetLives());

            hmgmode.DecreaseLives();
            Assert.Equal(7, hmgmode.GetLives());

            hmgmode.MakeGuess("b");
            Assert.Equal(6, hmgmode.GetLives());
        }

        [Fact]
        public void UserCanLoseTest()
        {
            Game hmgmode = CreateTestGame("a");
            string makeGuesses = "bcdefghijk";
            for (int i = 0; i < 8; i++)
                hmgmode.MakeGuess(makeGuesses[i].ToString());

            Assert.True(hmgmode.CheckGameEnd());
        }

        [Fact]
        public void UserCanGuessDifferentCasings()
        {
            Game hmgmode = CreateTestGame("a");

            hmgmode.MakeGuess("b");
            Assert.True(hmgmode.GetGuesses().Contains('b'));

            hmgmode.MakeGuess("C");
            Assert.True(hmgmode.GetGuesses().Contains('c'));

            int currLives = hmgmode.GetLives();

            hmgmode.MakeGuess("c");
            Assert.True(hmgmode.GetGuesses().Contains('c'));
            Assert.True(hmgmode.GetLives() == currLives);
        }


        [Fact]
        public void UserCannotGuessANonAlphabetChar()
        {
            Game hmgmode = CreateTestGame("a");
            Assert.Empty(hmgmode.GetGuesses());

            hmgmode.MakeGuess("%");
            Assert.Empty(hmgmode.GetGuesses());
        }

        [Fact]
        public void UserCannotGuessMultipleChars()
        {
            Game hmgmode = CreateTestGame("a");
            Assert.Empty(hmgmode.GetGuesses());

            hmgmode.MakeGuess("multiple chars");
            Assert.Empty(hmgmode.GetGuesses());
        }
    }
}