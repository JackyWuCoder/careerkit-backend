namespace CareerKitBackend.Main.APITrackerService.Model
{
	// TODO: Add more stats value once more services are implemented and refined
	public record class UsageStats
	{
		public static readonly int StartingUseCount = 20;
		public int CoverLetterAutoFillRemaining { get; private set; } = StartingUseCount;
		public int CoverLetterScratchService { get; private set; } = StartingUseCount;
		public int CoverLetterProofreadService { get; private set; } = StartingUseCount;
		public int InterviewQuestions { get; private set; } = StartingUseCount;
		public int ResumeAutoFillRemaining { get; private set; } = StartingUseCount;
		public int AdviceServiceRemaining { get; private set; } = StartingUseCount;
		public void Decrement(ServiceEndpointsEnum service)
		{
			switch (service)
			{
				case ServiceEndpointsEnum.CoverLetterAutofillService:
					CoverLetterAutoFillRemaining--;
					break;
				case ServiceEndpointsEnum.CoverLetterScratchService:
					CoverLetterScratchService--;
					break;
				case ServiceEndpointsEnum.CoverLetterProofreadService:
					CoverLetterProofreadService--;
					break;
				case ServiceEndpointsEnum.InterviewQuestionsService:
					InterviewQuestions--;
					break;
				case ServiceEndpointsEnum.ResumeAutofillService:
					ResumeAutoFillRemaining--;
					break;
				case ServiceEndpointsEnum.AdviceService:
					AdviceServiceRemaining--;
					break;
			}
		}
		public int GetRemainingUsage(ServiceEndpointsEnum service)
		{
			switch (service)
			{
				case ServiceEndpointsEnum.CoverLetterAutofillService:
					return CoverLetterAutoFillRemaining;

				case ServiceEndpointsEnum.CoverLetterScratchService:
					return CoverLetterScratchService;

				case ServiceEndpointsEnum.CoverLetterProofreadService:
					return CoverLetterProofreadService;

				case ServiceEndpointsEnum.InterviewQuestionsService:
					return InterviewQuestions;

				case ServiceEndpointsEnum.ResumeAutofillService:
					return ResumeAutoFillRemaining;

				case ServiceEndpointsEnum.AdviceService:
					return AdviceServiceRemaining;

				default: // Should never run with proper enum usage
					Console.Error.WriteLine("CRITICAL ERROR: Non-valid enum passed as parameter to GetRemainingUsage in UsageStats");
					throw new Exception("Non-valid enum passed as parameter to GetRemainingUsage in UsageStats");
			}
		}
	}
}
