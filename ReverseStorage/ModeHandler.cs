﻿using ReverseStorage.Abstraction;
using System;
using System.Collections.Generic;
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
            switch (mode)
            {
                case UserMode.RETRIEVE:
                    IWordService handler = _wordService;
                    handler.RetrieveAllWordsToConsole(@"C:\Users\mfinn\Desktop\ReverseStorage\ReverseStorage\SavedWords.txt");
                    break;
                case UserMode.INSERT:
                    IValidator validator = _validator;
                    if (validator.IsValid(word))
                    {
                    IWordInverter inverter = _wordInverter;
                    word = inverter.GetInvertedWord(word);

                    IWordService writer = _wordService;
                    writer.AddWord(@"C:\Users\mfinn\Desktop\ReverseStorage\ReverseStorage\SavedWords.txt", word);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
