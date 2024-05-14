namespace OpenAIApp.Services {
    public interface IOpenAIService {

        Task<string> CompleteSentence(string text);
        Task<string> CompleteSentenceAdvance(string text);
        Task<string> SuggestBetterCode(string code);
    }
}
