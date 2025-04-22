using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace CareerKitBackend.Main.APITrackerService.Model
{
	public record class UsageStats
	{
		public static readonly int StartingUseCount = 20;
		public int CoverLetterAutoFillRemaining { get; private set; } = StartingUseCount;

		public void Decrement(ServiceEndpointsEnum service)
		{
			switch(service)
			{
				case ServiceEndpointsEnum.CoverLetterAutofillService:
					CoverLetterAutoFillRemaining--;
					break;
			}
		}
		public int GetRemainingUsage(ServiceEndpointsEnum service)
		{
			switch(service)
			{
				case ServiceEndpointsEnum.CoverLetterAutofillService:
					return CoverLetterAutoFillRemaining;
				default: // Should never run with proper enum usage
					Console.WriteLine("CRITICAL ERROR: Non-valid enum passed as parameter to GetRemainingUsage in UsageStats");
					throw new Exception("Non-valid enum passed as parameter to GetRemainingUsage in UsageStats");					
			}			
		}
	}
}
