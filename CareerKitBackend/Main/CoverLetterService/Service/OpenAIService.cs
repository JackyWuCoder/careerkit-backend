using OpenAI_API;

namespace CareerKitBackend.Services
{
    public class OpenAIService
    {
        private readonly OpenAIAPI _api;

        public OpenAIService(string apiKey)
        {
            _api = new OpenAIAPI(apiKey);
        }

        public async Task<string> GenerateCoverLetterAsync(string template, string jobDescription)
        {
            string prompt = $"Using the following cover letter template:\n\n{template}\n\n" +
                         $"Add the following job description:\n\n{jobDescription}\n\n" +
                         $"Generate a tailored cover letter.";

            var result = await _api.Completions.GetCompletion(prompt);
            return result;
        }
    }
}