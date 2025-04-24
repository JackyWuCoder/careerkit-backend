using CareerKitBackend.Main.Utils.Exceptions;

namespace CareerKitBackend.Main.Utils
{
	public static class RequestUtils
	{
		public static string GetIPAddress(HttpContext context)
		{
			string? ip = context.Connection.RemoteIpAddress?.ToString();
			if (context.Request.Headers.ContainsKey("X-Forwarded-For"))
				ip = context.Request.Headers["X-Forwarded-For"].FirstOrDefault();

			if (string.IsNullOrEmpty(ip)) throw new NoIPException("Unable to identify user");
			else if (ip == "::1") return "127.0.0.1"; // Shows up as ::1 if using localhost
			return ip;
		}
	}
}
