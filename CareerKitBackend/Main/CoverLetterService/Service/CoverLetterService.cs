using CareerKitBackend.Main.CoverLetterService.Data;

namespace CareerKitBackend.Main.CoverLetterService.Service
{
	public class CoverLetterService
	{
		public string GetTemplateSystemInstructions()
		{
			return SystemInstructions.CoverLetterAutoFillInstructions;
		}
		public string GetScratchSystemInstructions()
		{
			return SystemInstructions.CoverLetterNoTemplateInstructions;
		}
		public string GenerateTemplateMessage(string template, string jobDescription)
		{
			return $"""
					Cover Letter Template: 
					{template}

					Job Description:
					{jobDescription}
				""".Trim();
		}
		public string GenerateScratchMessage(string jobDescription)
		{
			return $"""
				Job Description:
				{jobDescription}
				""".Trim();
		}
	}
}
