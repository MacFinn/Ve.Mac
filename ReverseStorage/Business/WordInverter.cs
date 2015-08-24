using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public class WordInverter : IWordInverter
    {
        public  string GetInvertedWord(string rawWord)
        {
            var charArray = rawWord.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
