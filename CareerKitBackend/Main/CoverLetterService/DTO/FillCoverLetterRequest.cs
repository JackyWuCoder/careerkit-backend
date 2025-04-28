namespace CareerKitBackend.Main.CoverLetterService.DTO
{
	public class FillCoverLetterRequest
	{
		public required string Template { get; set; }
		public required string JobDescription { get; set; }
	}
}
