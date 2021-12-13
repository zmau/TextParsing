using System;
using System.Net.Http;
using System.Threading.Tasks;
using TextParsingClient.Repo;
using System.Net;
using Microsoft.Extensions.Configuration;

namespace TextParsingClient
{
    public class ConsoleClient
    {
        public enum InputMode
        {
            FILE,
            CONSOLE,
            DATABASE
        }

        private InputMode _mode;

        public ConsoleClient(InputMode inputMode)
        {
            _mode = inputMode;
        }
        public async Task process()
        {
            ITextRepository repository = RepositoryFactory.NewRepository(_mode);
            string text = repository.GetText();
            Console.WriteLine(string.Format("Input text : {0} ", text));
            int result = await CountWordsAsync(text);
            Console.WriteLine(string.Format("Words count : {0}", result));
            Console.WriteLine();
        }

        /***
          * sends requests to server, and returns response as int
        */
        private async Task<int> CountWordsAsync(string text)
        {
            string apiUrl = ConfigurationFactory.GetConfiguration().GetValue<string>("apiUrl");
            string wholeUrl = string.Format("{0}/wordcounter/{1}", apiUrl, text);
            WebClient client = new ();
            var response = await client.DownloadStringTaskAsync(new Uri(wholeUrl));
            return Convert.ToInt32(response);
        }
    }
}
