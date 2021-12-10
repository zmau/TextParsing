using System.IO;

namespace TextParsingClient.Repo
{
    public class FileRepository : ITextRepository
    {
        private static string FILE_PATH = @"C:\dev\TextParsing\TextParsingProject\TextParsingClient\input.txt";
        public string GetText()
        {
            return File.ReadAllText(FILE_PATH);
        }
    }
}
