using CareerKitBackend.Main.InterviewService.Data;

namespace CareerKitBackend.Main.InterviewService.Service
{
	public class InterviewService
	{
		public string GetGenerateQuestionsSystemInstructions()
		{
			return SystemInstructions.InterviewQuestionsInstructions;
		}
		public string GenerateQuestionsMessage(string jobDescription)
		{
			return $"""
				Job Description:
				{jobDescription}
				""".Trim();
		}
	}
}
