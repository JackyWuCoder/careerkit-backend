namespace CareerKitBackend.Main.CoverLetterService.DTO
{
	public class CoverLetterResponse
	{
		public required string Result { get; set; }
		public CoverLetterResponse(string content)
		{
			Result = content;
		}
	}
}
