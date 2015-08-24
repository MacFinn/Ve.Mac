using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStorage
{
    public interface IFileWrapper
    {
        void AppendText(string path, string content);
        List<string> ReadFile(string filePath);
    }
}
