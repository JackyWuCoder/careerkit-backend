using CareerKitBackend.Main.APITrackerService.DTO;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.Utils;
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
			try
			{
				string requestIPAddress = RequestUtils.GetIPAddress(HttpContext);
				UsageStats stats = trackerService.GetUsageStat(requestIPAddress);
				return Ok(new GetUsageStatsResponse(stats));
			} 
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
		}
	}
}
