using CareerKitBackend.Main.InterviewService.Data;

namespace CareerKitBackend.Main.InterviewService.Service
{
	public class InterviewService
	{
		public string GetGenerateQuestionsSystemInstructions()
		{
			return SystemInstructions.InterviewQuestionsInstructions;
		}
		public string GetGenerateAnswersFeedbackSystemInstructions()
		{
			return SystemInstructions.InterviewAnswersInstructions;
		}
		public string GenerateQuestionsMessage(string jobDescription)
		{
			return $"""
				Job Description:
				{jobDescription}
				""".Trim();
		}
		public string GenerateAnswersFeedbackMessage(string jobDescription, string question, string answer)
		{
			return $"""
				Job Description:
				{jobDescription}

				Interview Question:
				{question}

				Interview Answer:
				{answer}
				""".Trim();
		}
	}
}
