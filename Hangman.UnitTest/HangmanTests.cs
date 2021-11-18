using System;
using Xunit;
using Hangman;


namespace HangmanTests
{
    public class HangmanTests
    {
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
            Guess guess = new Guess("a", new HangmanGamemode("Guess Added correctly test"));
            
            //Assert.Equal();
        }

        [Fact]
        public void DecreasesLivesTest()
        {
            
        }
        
        [Fact]
        public void AbleToWinTest()
        {
            
        }
        
        [Fact]
        public void AbleToLoseTest()
        {
            
        }
        
        [Fact]
        public void InvalidGuessTest()
        {
            
        }
        
        [Fact]
        public void DuplicateGuessTest()
        {
            
        }
    }
    
    
}