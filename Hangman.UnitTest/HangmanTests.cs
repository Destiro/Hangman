using System;
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

        [Fact]
        public void WordGeneratedTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Word Generated correctly test");
            Assert.Null(hmgmode.GetWord());
            Assert.Equal("", hmgmode.GetGuessedWord().ToString());

            hmgmode.GenerateWord();
            Assert.NotNull(hmgmode.GetWord());
            Assert.True(hmgmode.GetWord().Length > 0);
        } 
        
        [Fact]
        public void GuessAddedCorrectlyTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Guess added correctly test");
            hmgmode.Word = "abc";
            for(int i=0; i<hmgmode.Word.Length; i++)
                hmgmode.guessedWord.Append('_');
            
            Assert.Empty(hmgmode.GetGuesses());
            new Guess("a", hmgmode);
            Assert.NotEmpty(hmgmode.GetGuesses());
        }
        
        [Fact]
        public void DuplicateGuessTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Guess added correctly test");
            hmgmode.Word = "hello";
            Assert.Empty(hmgmode.GetGuesses());
            
            Guess guess = new Guess("a", hmgmode);
            Assert.True(1 == hmgmode.GetGuesses().Count);
            
            Guess guess2 = new Guess("a", hmgmode);
            Assert.True(1 == hmgmode.GetGuesses().Count);
        }
        
        [Fact]
        public void AbleToWinTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to Win test");
            hmgmode.Word = "hello";
            for(int i=0; i<hmgmode.Word.Length; i++)
                hmgmode.guessedWord.Append('_');
            Assert.False(hmgmode.gameEnded);
            
            new Guess("h", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.False(hmgmode.gameEnded);
            
            new Guess("e", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.False(hmgmode.gameEnded);
            
            new Guess("l", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.False(hmgmode.gameEnded);
            
            new Guess("o", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.True(hmgmode.gameEnded);
        }

        [Fact]
        public void DoubleUpLetterTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to add double letters test");
            hmgmode.Word = "abcabcab";
            for(int i=0; i<hmgmode.Word.Length; i++)
                hmgmode.guessedWord.Append('_');
            
            new Guess("c", hmgmode);
            Assert.Equal("__c__c__", hmgmode.GetGuessedWord().ToString());
            
            new Guess("a", hmgmode);
            Assert.Equal("a_ca_ca_", hmgmode.GetGuessedWord().ToString());
        }

        [Fact]
        public void DecreasesLivesTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to decrease lives test");
            hmgmode.Word = "a";
            
            Assert.Equal(8, hmgmode.lives);
            
            hmgmode.DecreaseLives();
            Assert.Equal(7, hmgmode.lives);
            
            new Guess("b", hmgmode);
            Assert.Equal(6, hmgmode.lives);
        }

        [Fact]
        public void AbleToLoseTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to lose test");
            hmgmode.Word = "a";
            string makeGuesses = "bcdefghijk";
            for (int i = 0; i < 8; i++)
            {
                new Guess(makeGuesses[i].ToString(), hmgmode);
                hmgmode.CheckWinLoss();
            }
            Assert.True(hmgmode.gameEnded);
        }
        
        [Fact]
        public void CasingTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to change letter casing test");
            hmgmode.Word = "a";
            
            new Guess("b", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('b'));
            
            new Guess("C", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('c'));

            int currLives = hmgmode.lives;
            
            new Guess("c", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('c'));
            Assert.True(hmgmode.lives == currLives);

        }
        
        [Fact]
        public void InvalidGuessTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to change letter casing test");
            hmgmode.Word = "a";

            new Guess("multiple chars", hmgmode);
            Assert.Empty(hmgmode.GetGuesses());

            new Guess("%", hmgmode);
            Assert.Empty(hmgmode.GetGuesses());
        }
    }
    
    
}