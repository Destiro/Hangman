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
                hmgmode.GuessedWord.Append('_');
            
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
                hmgmode.GuessedWord.Append('_');
            Assert.False(hmgmode.GameEnded);
            
            new Guess("h", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.False(hmgmode.GameEnded);
            
            new Guess("e", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.False(hmgmode.GameEnded);
            
            new Guess("l", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.False(hmgmode.GameEnded);
            
            new Guess("o", hmgmode);
            hmgmode.CheckWinLoss();
            Assert.True(hmgmode.GameEnded);
        }

        [Fact]
        public void DoubleUpLetterTest()
        {
            HangmanGamemode hmgmode = new HangmanGamemode("Able to add double letters test");
            hmgmode.Word = "abcabcab";
            for(int i=0; i<hmgmode.Word.Length; i++)
                hmgmode.GuessedWord.Append('_');
            
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
            
            Assert.Equal(8, hmgmode.Lives);
            
            hmgmode.DecreaseLives();
            Assert.Equal(7, hmgmode.Lives);
            
            new Guess("b", hmgmode);
            Assert.Equal(6, hmgmode.Lives);
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
            Assert.True(hmgmode.GameEnded);
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

            int currLives = hmgmode.Lives;
            
            new Guess("c", hmgmode);
            Assert.True(hmgmode.GetGuesses().Contains('c'));
            Assert.True(hmgmode.Lives == currLives);

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