using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextParsingServer.Servces.WordCounter;

namespace TextParsingServer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordCounterController : ControllerBase
    {

        private readonly IWordCounter _service;
        private readonly ILogger<WordCounterController> _logger;

        public WordCounterController(ILogger<WordCounterController> logger, IWordCounter service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet("{text}")]
        public int GetWordCount(string text)
        {
            return _service.getWordsCount(text); 
        }
    }
}
