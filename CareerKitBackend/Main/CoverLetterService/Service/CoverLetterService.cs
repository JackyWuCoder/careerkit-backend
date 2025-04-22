using Betalgo.Ranul.OpenAI.Managers;
using CareerKitBackend.Main.CoverLetterService.Data;

namespace CareerKitBackend.Main.CoverLetterService.Service
{
	public class CoverLetterService
	{		
		public string GetSystemInstructions()
		{
			return SystemInstructions.CoverLetterAutoFillInstructions;
		}
		public string GenerateUserMessage(string template, string jobDescription)
		{
			return $"""
					Cover Letter Template: 
					{template}

					Job Description:
					{jobDescription}
				""".Trim();
		}
	}
}
