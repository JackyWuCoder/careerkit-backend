using CareerKitBackend.Main.APITrackerService.Model;

namespace CareerKitBackend.Main.APITrackerService.Service
{
	// TODO: Implement a clock that resets API counts every 24 hours at a specific time
	public class TrackerService
	{
		private readonly Dictionary<string, UsageStats> _ipUsage = [];

		public void DecrementUsage(ServiceEndpointsEnum service, string IPAddress)
		{
			if (!_ipUsage.ContainsKey(IPAddress)) AddNewIPStats(IPAddress, service);
			_ipUsage[IPAddress].Decrement(service);
		}

		public UsageStats GetUsageStat(string IPAddress)
		{
			if(!_ipUsage.TryGetValue(IPAddress, out UsageStats? stats)) return AddNewIPStats(IPAddress);
			return stats;
		}

		public int GetRemainingUse(ServiceEndpointsEnum service, string IPAddress)
		{
			if (!_ipUsage.TryGetValue(IPAddress, out UsageStats? value))
			{
				UsageStats stats = AddNewIPStats(IPAddress);
				return stats.GetRemainingUsage(service);
			}
			return value.GetRemainingUsage(service);
		}

		public bool CanUseService(ServiceEndpointsEnum service, string IPAddress)
		{
			if (!_ipUsage.TryGetValue(IPAddress, out UsageStats? value))
			{
				AddNewIPStats(IPAddress);
				return true;
			}
			return value.GetRemainingUsage(service) > 0;
		}

		public void ResetUsages()
		{
			_ipUsage.Clear();
		}

		// Adds a new IP to the dictionary, will automatically decrement if a service is provided from which it was called from
		private UsageStats AddNewIPStats(string IPAddress, ServiceEndpointsEnum? service = null)
		{
			UsageStats newStats = new();
			_ipUsage.Add(IPAddress, newStats);
			if (service != null) newStats.Decrement((ServiceEndpointsEnum) service);			
			return newStats;
		}
	}
}
