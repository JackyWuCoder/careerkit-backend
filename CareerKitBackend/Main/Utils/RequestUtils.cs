using CareerKitBackend.Main.Utils.Exceptions;

namespace CareerKitBackend.Main.Utils
{
	public static class RequestUtils
	{
		public static string GetIPAddress(HttpContext context)
		{
			string? ip = context.Request.Headers.ContainsKey("X-Forwarded-For") ?
				context.Request.Headers["X-Forwarded-For"].FirstOrDefault() :
				context.Connection.RemoteIpAddress?.ToString();

			if (string.IsNullOrEmpty(ip)) throw new NoIPException("Unable to identify user");
			return ip;
		}
		// Throws exception if request is not valid
		public static void ValidateRequestFields(params string[] fields)
		{
			foreach (string field in fields)
			{
				if (string.IsNullOrEmpty(field)) throw new MissingFieldException("Missing one or more fields in request");
			}
		}
	}
}
