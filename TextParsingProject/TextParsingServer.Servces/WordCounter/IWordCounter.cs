using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextParsingServer.Servces.WordCounter
{
    public interface IWordCounter
    {
        int getWordsCount(string text);
    }
}
