namespace CareerKitBackend.Main.AIService.Exceptions
{
	public class ChatRequestErrorException : Exception
	{
		public ChatRequestErrorException() { }
		public ChatRequestErrorException(string message) : base(message) { }
		public ChatRequestErrorException(string message, Exception innerException) : base(message, innerException) { }
	}
}
