
using Microsoft.Extensions.Options;
using OpenAI_API.Completions;
using OpenAI_API.Models;
using OpenAIApp.Configurations;

namespace OpenAIApp.Services {
    public class OpenAIService : IOpenAIService {

        private readonly OpenAIConfig _openAiConfig;

        public OpenAIService(IOptionsMonitor<OpenAIConfig> optionsMonitor)
        {
            _openAiConfig = optionsMonitor.CurrentValue;
        }

        public async Task<string> CompleteSentence(string text) {
            // api instance 
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
            var result = await api.Completions.GetCompletion(text);

            return result;
        }

        public async Task<string> CompleteSentenceAdvance(string text) {
            // api instance 
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
            var result = await api.Completions.CreateCompletionAsync(new CompletionRequest(text, model:Model.AdaText, temperature:0.1));

            return result.Completions[0].Text;
        }

        public async Task<string> SuggestBetterCode(string code) {
            // api instance 
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);
            var chat = api.Chat.CreateConversation();
            
            chat.AppendSystemMessage("You are a teacher of C# programming language and make suggestions to developers for writting better code. If a developer gives you a code you should make suggestions, on how to write it better.");
            chat.AppendUserInput(code);

            var responce = await chat.GetResponseFromChatbotAsync();
            return responce;

        }
    }
}
