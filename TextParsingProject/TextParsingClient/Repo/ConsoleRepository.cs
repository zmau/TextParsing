using System;

namespace TextParsingClient.Repo
{
    public class ConsoleRepository : ITextRepository
    {
        public string GetText()
        {
            Console.WriteLine("Write text to parse : ");
            return Console.ReadLine();
        }
    }
}
