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
            return _word.Contains(guess);
        }

        public string GetWord()
        {
            return _word;
        }
    }
}