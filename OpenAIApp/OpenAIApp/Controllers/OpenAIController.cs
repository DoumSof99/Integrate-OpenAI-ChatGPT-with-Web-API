using Microsoft.AspNetCore.Mvc;
using OpenAIApp.Services;

namespace OpenAIApp.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class OpenAIController : ControllerBase {

        private readonly ILogger<OpenAIController> _logger;
        private readonly IOpenAIService _openAIService;

        public OpenAIController(ILogger<OpenAIController> logger, IOpenAIService openAIService)
        {
            _logger = logger;
            _openAIService = openAIService;
        }

        [HttpPost()]
        [Route("CompleteSentence")]
        public async Task<IActionResult> CompleteSentence(string text) {
            var result = await _openAIService.CompleteSentence(text);
            return Ok(result);
        }

        [HttpPost()]
        [Route("CompleteSentenceAdvance")]
        public async Task<IActionResult> CompleteSentenceAdvance(string text) {
            var result = await _openAIService.CompleteSentenceAdvance(text);
            return Ok(result);
        }

        [HttpPost()]
        [Route("SuggestBetterCode")]
        public async Task<IActionResult> SuggestBetterCode(string code) {
            var result = await _openAIService.SuggestBetterCode(code);
            return Ok(result);
        }
    }
}
