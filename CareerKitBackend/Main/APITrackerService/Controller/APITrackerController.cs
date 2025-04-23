using CareerKitBackend.Main.APITrackerService.DTO;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.APITrackerService.Service;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.APITrackerService.Controller
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class APITrackerController(TrackerService trackerService) : ControllerBase
	{
		[HttpPost]
		public IActionResult GetAPIStats()
		{
			// TODO: Implement getting IP address from requester
			string requestIPAddress = "fillerIPHere";
			UsageStats stats = trackerService.GetUsageStat(requestIPAddress);
			return Ok(new GetUsageStatsResponse(stats));
		}
	}
}
