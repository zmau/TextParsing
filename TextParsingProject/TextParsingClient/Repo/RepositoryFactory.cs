using static TextParsingClient.ConsoleClient;

namespace TextParsingClient.Repo
{
    public class RepositoryFactory
{
        public static ITextRepository NewRepository(InputMode mode)
        {
            switch (mode)
            {
                case InputMode.FILE: return new FileRepository();
                case InputMode.CONSOLE: return new ConsoleRepository();
                case InputMode.DATABASE: return new DbRepository();
                default: return new FileRepository(); // TODO throw exception instead of setting default!
            }
        }
    }
}
