using Betalgo.Ranul.OpenAI.Interfaces;
using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;


namespace CareerKitBackend.Services
{
    public class OpenAIService
    {
        private readonly IOpenAIService _openAi;

        public OpenAIService(IOpenAIService openAi)
        {
           _openAi = openAi;
        }

        public async Task<string> GenerateCoverLetterAsync(string template, string jobDescription)
        {
            var messages = new List<ChatMessage>
            {
                ChatMessage.FromSystem("You generate cover letters from templates and job descriptions."),
                ChatMessage.FromUser($"Template:\n{template}\n\nJob Description:\n{jobDescription}")
            };
        
             var result = await _openAi.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
            {
                Messages = messages,
                Model = Models.Gpt_4o,
                Temperature = 0.7f
            });

            if (result.Successful)
            {
                return result.Choices.First().Message.Content;
            }
            else 
            {
                throw new Exception(result.Error?.Message ?? "Failed to generate completion.");
            }
        }
    }
}