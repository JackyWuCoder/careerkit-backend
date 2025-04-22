using CareerKitBackend.Main.APITrackerService.Model;

namespace CareerKitBackend.Main.APITrackerService.Service
{
	// TODO: Implement a clock that resets API counts every 24 hours at a specific time
	public class TrackerService
	{
		private readonly Dictionary<string, UsageStats> _ipUsage = [];

		public void DecrementUsage(ServiceEndpointsEnum service, string IPAddress)
		{			
			if (!_ipUsage.ContainsKey(IPAddress))
			{
				UsageStats newStats = new();
				newStats.Decrement(service);
				_ipUsage.Add(IPAddress, newStats);
				return;
			}
			_ipUsage[IPAddress].Decrement(service);
		}

		public int GetRemainingUse(ServiceEndpointsEnum service, string IPAddress)
		{
			if (!_ipUsage.TryGetValue(IPAddress, out UsageStats? value)) return UsageStats.StartingUseCount;
			return value.GetRemainingUsage(service);
		}

		public bool CanUseService(ServiceEndpointsEnum service, string IPAddress)
		{
			if (!_ipUsage.TryGetValue(IPAddress, out UsageStats? value)) return true; // New IPs will create UsageStats upon DecrementUsage invocation
			return value.GetRemainingUsage(service) > 0;
		}

		public void ResetUsages()
		{
			_ipUsage.Clear();
		}
	}
}
