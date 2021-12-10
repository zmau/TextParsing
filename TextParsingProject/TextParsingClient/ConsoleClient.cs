using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TextParsingClient.Repo;

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
        public async void process()
        {
            ITextRepository repository = RepositoryFactory.NewRepository(_mode);
            string text = repository.GetText();
            Console.WriteLine("input text : " + text);
            //await CountWords(text);
            await PostRequest(text);

        }

        private async Task PostRequest(string text)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("text", text)
                    });
                    var result = await client.PostAsync("/wordcounter/GetWordCountByPost", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private async Task CountWords(string text)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Clear();
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                string wholeUrl = string.Format("{0}/gettext/{1}", API_URL, text);
                var stringTask = _httpClient.GetStringAsync(wholeUrl); 

                var msg = await stringTask;
                Console.Write(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
