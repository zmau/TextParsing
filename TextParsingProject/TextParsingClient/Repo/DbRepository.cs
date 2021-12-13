using Microsoft.Extensions.Configuration;
using TextParsingClient.DB;

namespace TextParsingClient.Repo
{
    public class DbRepository : ITextRepository
    {
        public string GetText()
        {
            string connectionString = ConfigurationFactory.GetConfiguration().GetConnectionString("orionDB");
            ParsingDBContext context = new ParsingDBContext(connectionString);
            var input = context.InputText.Find(3); // sync call, because of interface!
            return input.Text;
        }

    }
}
