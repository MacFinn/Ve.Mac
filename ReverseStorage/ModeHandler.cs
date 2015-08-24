using ReverseStorage.Abstraction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public class ModeHandler : IModeHandler
    {
        private readonly IWordService _wordService;
        private readonly IValidator _validator;
        private readonly IWordInverter _wordInverter;

        public ModeHandler(IWordService wordService, IValidator validator, IWordInverter wordInverter)
        {
            _wordService = wordService;
            _validator = validator;
            _wordInverter = wordInverter;
        }

        public void OrchestrateMode(UserMode mode, string word)
        {
            var path = Path.Combine(Environment.CurrentDirectory, "SavedWords.txt");
            switch (mode)
            {
                case UserMode.RETRIEVE:
                    IWordService handler = _wordService;
                    handler.RetrieveAllWordsToConsole(path);
                    break;
                case UserMode.INSERT:
                    IValidator validator = _validator;
                    if (validator.IsValid(word))
                    {
                    IWordInverter inverter = _wordInverter;
                    word = inverter.GetInvertedWord(word);

                    IWordService writer = _wordService;
                    writer.AddWord(path, word);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
