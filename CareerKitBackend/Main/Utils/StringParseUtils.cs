namespace CareerKitBackend.Main.Utils
{
	public static class StringParseUtils
	{
		public static string ExtractSection(string content, string sectionName)
		{
			string delimiter = $"[---{sectionName}---]";
			int indexFrom = content.IndexOf(delimiter) + delimiter.Length;
			int indexTo = content.LastIndexOf(delimiter);
			return content[indexFrom..indexTo].Trim();
		}
		public static List<string> ExtractList(string content)
		{
			return content.Split("====", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList();
		}
	}
}
