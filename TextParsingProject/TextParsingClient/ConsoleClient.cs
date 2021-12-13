using System;
using System.Net.Http;
using System.Threading.Tasks;
using TextParsingClient.Repo;

using System.Net;

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
        private static string API_URL = "https://localhost:44379";

        private readonly HttpClient _httpClient;

        public ConsoleClient(InputMode inputMode)
        {
            _mode = inputMode;
            _httpClient = new HttpClient();
        }
        public async Task process()
        {
            ITextRepository repository = RepositoryFactory.NewRepository(_mode);
            string text = repository.GetText();
            Console.WriteLine("input text : " + text);
            int result = await CountWordsAsync(text);
            Console.WriteLine(string.Format("text : {0} ", text));
            Console.WriteLine(string.Format("Words count : {0}", result));
            Console.WriteLine();
        }

        private async Task<int> CountWordsAsync(string text)
        {
            string wholeUrl = string.Format("{0}/wordcounter/{1}", API_URL, text);
            var client = new WebClient();
            var response = await client.DownloadStringTaskAsync(new Uri(wholeUrl));
            return Convert.ToInt32(response);
        }
    }
}
