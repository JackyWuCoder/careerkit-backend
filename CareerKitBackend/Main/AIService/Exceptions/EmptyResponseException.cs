namespace CareerKitBackend.Main.AIService.Exceptions
{
	public class EmptyResponseException : Exception
	{
		public EmptyResponseException() : base() { }
		public EmptyResponseException(string message) : base(message) { }
		public EmptyResponseException(string message, Exception innerException) : base(message, innerException) { }
	}
}
