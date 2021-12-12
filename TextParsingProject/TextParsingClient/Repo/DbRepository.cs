using System;
using System.Collections.Generic;
using System.Linq;
using TextParsingClient.DB;

namespace TextParsingClient.Repo
{
    public class DbRepository : ITextRepository
    {
        public string GetText()
        {
            string CONN_STRING = "Data Source=.;Initial Catalog=orion3;Integrated Security=True";
            ParsingDBContext context = new ParsingDBContext(CONN_STRING);
            var input = context.InputText.Where(input => input.ID == 2);
            return input.First().Text;
        }

    }
}
