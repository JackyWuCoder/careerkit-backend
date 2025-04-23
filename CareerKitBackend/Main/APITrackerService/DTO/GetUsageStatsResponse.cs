using CareerKitBackend.Main.APITrackerService.Model;

namespace CareerKitBackend.Main.APITrackerService.DTO
{
	public class GetUsageStatsResponse(UsageStats stats)
	{
		public int CoverLetterAutofill { get; set; } = stats.CoverLetterAutoFillRemaining;
		public int ResumeAutofill { get; set; } = stats.ResumeAutoFillRemaining;
		public int AdviceService { get; set; } = stats.AdviceServiceRemaining;
	}
}
