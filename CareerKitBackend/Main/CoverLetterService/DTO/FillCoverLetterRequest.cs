namespace CareerKitBackend.Main.CoverLetterService.DTO
{
	public class FillCoverLetterRequest
	{
		public required string Template { get; set; }
		public string? JobDescription { get; set; }
	}
}
