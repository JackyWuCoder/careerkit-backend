namespace CareerKitBackend.Main.InterviewService.DTO
{
	public class InterviewAnswersFeedbackRequest
	{
		public required string JobDescription { get; set; }
		public required string InterviewQuestion { get; set; }
		public required string InterviewAnswer { get; set; }
	}
}
