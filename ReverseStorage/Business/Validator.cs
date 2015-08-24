using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public class Validator : IValidator
    {
        public bool IsValid(string word)
        {
            if (word.Any(c => char.IsDigit(c)))
            {
                return false;
            }
            return true;
        }
    }
}
