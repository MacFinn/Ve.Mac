using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public interface IValidator
    {
        bool IsValid(string word);
    }
}
