using ReverseStorage.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public class WordService : IWordService
    {
        private readonly IFileWrapper _fileWrapper;

        public WordService(IFileWrapper fileWrapper)
        {
            _fileWrapper = fileWrapper;
        }

        public void AddWord(string path, string reversedWord)
        {
            _fileWrapper.AppendText(path, reversedWord + Environment.NewLine);
        }

        public void RetrieveAllWordsToConsole(string path)
        {
            var fileContent = _fileWrapper.ReadFile(path);

            foreach (string line in fileContent)
            {
                Console.WriteLine(line);
            }
        }

        public List<string> RetrieveAllWords(string path)
        {
            List<string> words = new List<string>();

            var fileContent = _fileWrapper.ReadFile(path);

            foreach (string line in fileContent)
            {
                words.Add(line);
            }

            return words;
        }
    }
}
