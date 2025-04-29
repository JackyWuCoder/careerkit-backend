namespace CareerKitBackend.Main.CoverLetterService.DTO
{
	public class CoverLetterResponse(string content)
	{
		public string Result { get; set; } = content;
	}
}
