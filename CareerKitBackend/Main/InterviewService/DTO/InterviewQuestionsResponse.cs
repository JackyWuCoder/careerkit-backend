using CareerKitBackend.Main.Utils;
using System.Diagnostics.CodeAnalysis;

namespace CareerKitBackend.Main.InterviewService.DTO
{
	public class InterviewQuestionsResponse
	{
		public required List<string> Questions { get; set; }
		[SetsRequiredMembers]
		public InterviewQuestionsResponse(string content)
		{
			Questions = StringParseUtils.ExtractList(content);
		}
	}
}
