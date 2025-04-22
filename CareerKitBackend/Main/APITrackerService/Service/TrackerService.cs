using CareerKitBackend.Main.APITrackerService.Model;

namespace CareerKitBackend.Main.APITrackerService.Service
{
	public class TrackerService
	{
		private readonly Dictionary<string, UsageStats> ipUsage = [];

		public void DecrementUsage(ServiceEndpointsEnum service, string IPAddress)
		{			
			if (!ipUsage.ContainsKey(IPAddress))
			{
				UsageStats newStats = new();
				newStats.Decrement(service);
				ipUsage.Add(IPAddress, newStats);
				return;
			}
			ipUsage[IPAddress].Decrement(service);
		}

		public void ResetUsages()
		{
			ipUsage.Clear();
		}
	}
}
