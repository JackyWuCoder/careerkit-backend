using Betalgo.Ranul.OpenAI.Interfaces;
using Betalgo.Ranul.OpenAI.ObjectModels;
using Betalgo.Ranul.OpenAI.ObjectModels.RequestModels;
using CareerKitBackend.Main.AIService.Exceptions;


namespace CareerKitBackend.Main.AIService.Service
{
	public class OpenAIService
	{
		private readonly IOpenAIService _openAi;

		public OpenAIService(IOpenAIService openAi)
		{
			_openAi = openAi;
		}

		public async Task<string> SendMessage(string instructions, string message)
		{
			var messages = new List<ChatMessage>
			{
				ChatMessage.FromSystem(instructions),
				ChatMessage.FromSystem(message)
			};
			var result = await _openAi.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
			{
				Messages = messages,
				Model = Models.Gpt_4o,
				Temperature = 0.7f
			});
			if (!result.Successful) throw new ChatRequestErrorException("Failed to generate chat");

			string? response = result.Choices.First().Message.Content;
			if (response == "NULL") throw new BadChatRequestException("The request cannot be processed due to the content not aligning with the purposes of the service");
			return response ?? throw new EmptyResponseException("The response received had no content");
		}
	}
}