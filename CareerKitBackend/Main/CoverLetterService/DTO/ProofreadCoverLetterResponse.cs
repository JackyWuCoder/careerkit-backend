namespace CareerKitBackend.Main.CoverLetterService.DTO
{
	public class ProofreadCoverLetterResponse(string letter, string advice)
	{
		public string Letter { get; set; } = letter;
		public string Advice { get; set; } = advice;
	}
}
