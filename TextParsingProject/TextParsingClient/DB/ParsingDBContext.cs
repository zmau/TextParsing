using System.Data.Entity;
using TextParsingClient.DB.entities;

namespace TextParsingClient.DB
{
    public class ParsingDBContext : DbContext
    {
        public ParsingDBContext(string connString)
        {
            Database.Connection.ConnectionString = connString;
            Database.SetInitializer<ParsingDBContext>(new DBInitializer());
        }
        public DbSet<InputText> InputText { get; set; }

    }
}
