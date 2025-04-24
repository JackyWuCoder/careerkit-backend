namespace CareerKitBackend.Main.Utils.Exceptions
{
	public class NoIPException : Exception
	{
		public NoIPException() { }
		public NoIPException(string message) : base(message) { }
		public NoIPException(string message,  Exception innerException) : base(message, innerException) { }
	}
}
