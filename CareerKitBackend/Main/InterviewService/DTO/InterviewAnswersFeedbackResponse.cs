using System.Diagnostics.CodeAnalysis;

namespace CareerKitBackend.Main.InterviewService.DTO
{
	public class InterviewAnswersFeedbackResponse
	{
		public required string Feedback { get; set; }

		[SetsRequiredMembers]
		public InterviewAnswersFeedbackResponse(string content)
		{
			Feedback = content;
		}
	}
}
