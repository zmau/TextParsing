using static TextParsingClient.ConsoleClient;

namespace TextParsingClient.Repo
{
    public class RepositoryFactory
{
        public static ITextRepository NewRepository(InputMode mode)
        {
            switch (mode)
            {
                case InputMode.FILE:
                    return new FileRepository();
                case InputMode.CONSOLE:
                    return new ConsoleRepository();
                default:
                    return new FileRepository();
            }
        }
    }
}
