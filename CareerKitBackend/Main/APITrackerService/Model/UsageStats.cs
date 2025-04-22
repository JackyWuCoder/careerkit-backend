using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace CareerKitBackend.Main.APITrackerService.Model
{
	public record class UsageStats
	{
		public int CoverLetterAutoFillRemaining { get; private set; } = 20;

		public void Decrement(ServiceEndpointsEnum service)
		{
			switch(service)
			{
				case ServiceEndpointsEnum.CoverLetterAutofillService:
					CoverLetterAutoFillRemaining--;
					break;
			}
		}
	}
}
