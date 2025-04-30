using CareerKitBackend.Main.APITrackerService.Model;

namespace CareerKitBackend.Main.APITrackerService.DTO
{
	public class GetUsageStatsResponse(UsageStats stats)
	{
		public int CoverLetterAutofill { get; set; } = stats.CoverLetterAutoFillRemaining;
		public int CoverLetterFromScratch { get; set; } = stats.CoverLetterScratchService;
		public int CoverLetterProofread { get; set; } = stats.CoverLetterProofreadService;
		public int InterviewQuestions { get; set; } = stats.InterviewQuestions;
		public int ResumeAutofill { get; set; } = stats.ResumeAutoFillRemaining;
		public int AdviceService { get; set; } = stats.AdviceServiceRemaining;
	}
}
