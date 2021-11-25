using System.Text;

namespace Hangman
{
    public class Word
    {
        private static string _word;
        
        public Word(string word)
        {
            _word = word;
        }

        public bool CheckInWord(char guess)
        {
            for (var i = 0; i < _word.Length; i++)
                if (_word[i].Equals(guess))
                    return true;
            
            return false;
        }

        public StringBuilder AddGuesses(StringBuilder currGuesses, char guess)
        {
            for (var i = 0; i < _word.Length; i++)
                if (_word[i].Equals(guess))
                    currGuesses[i] = guess;
            
            return currGuesses;
        }

        public string GetWord()
        {
            return _word;
        }
    }
}