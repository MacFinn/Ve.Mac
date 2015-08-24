using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReverseStorage
{
    public class FileWrapper : IFileWrapper
    {
        public void AppendText(string path, string content)
        {
            File.AppendAllText(path, content);
        }
        public List<string> ReadFile(string filePath)
        {
            var lineList = new List<string>();
            var file = new FileInfo(filePath);

            using (var reader = new StreamReader(filePath))
            {
                string currentLine = reader.ReadLine();
                while (currentLine != null)
                {
                    lineList.Add(currentLine);
                    currentLine = reader.ReadLine();
                }
            }

            return lineList;
        }
    }
}
