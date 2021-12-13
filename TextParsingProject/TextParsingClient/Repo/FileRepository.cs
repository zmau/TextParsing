using System;
using System.IO;

namespace TextParsingClient.Repo
{
    public class FileRepository : ITextRepository
    {
        public string GetText()
        {
            string filePath = string.Format("{0}\\{1}", Environment.CurrentDirectory, "input.txt");
            return File.ReadAllText(filePath);
        }
    }
}
