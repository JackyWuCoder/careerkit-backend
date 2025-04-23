namespace CareerKitBackend.Main.AIService.Exceptions
{
	public class BadChatRequestException : Exception
	{
		public BadChatRequestException() { }
		public BadChatRequestException(string message) : base(message) { }
		public BadChatRequestException(string message, Exception innerException) : base(message, innerException) { }
	}
}
