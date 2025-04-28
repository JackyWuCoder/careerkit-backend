using CareerKitBackend.Main.CoverLetterService.Data;
using CareerKitBackend.Main.Utils;

namespace CareerKitBackend.Main.CoverLetterService.Service
{
	public class CoverLetterService
	{
		public string GetTemplateSystemInstructions()
		{
			return FileParser.ReadFile("CoverLetterAutoFillInstructions.txt");
		}
		public string GetScratchSystemInstructions()
		{
			return FileParser.ReadFile("CoverLetterNoTemplateInstructions.txt");
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
