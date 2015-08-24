using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage.Abstraction
{
    public interface IWordService
    {
        void AddWord(string path, string reversedWord);
        void RetrieveAllWordsToConsole(string path);
    }
}
