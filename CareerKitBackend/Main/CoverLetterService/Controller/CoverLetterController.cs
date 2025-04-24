using CareerKitBackend.Main.CoverLetterService.DTO;
using CareerKitBackend.Main.AIService.Service;
using Microsoft.AspNetCore.Mvc;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.AIService.Exceptions;
using CareerKitBackend.Main.Utils;

namespace CareerKitBackend.Main.CoverLetterService.Controller
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CoverLetterController(OpenAIService openAiService, TrackerService trackerService, Service.CoverLetterService coverLetterService) : ControllerBase
	{
		[HttpPost]
		public async Task<IActionResult> Generate([FromBody] FillCoverLetterRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.Template) || string.IsNullOrWhiteSpace(request.JobDescription))
			{
				return BadRequest("Template and Job Description are required.");
			}

			// Get IP address
			string ipAddress;
			try
			{
				ipAddress = RequestUtils.GetIPAddress(HttpContext);
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			// Check if IP can use service
			if (!trackerService.CanUseService(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress))
			{
				return BadRequest("API exhausted, wait for daily reset.");
			}
			// Use AI Service
			try
			{
				string content = await openAiService.SendMessage
				(
					coverLetterService.GetSystemInstructions(), 
					coverLetterService.GenerateUserMessage(request.Template, request.JobDescription)
				);
				trackerService.DecrementUsage(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress);
				return Ok(content);
			} 
			catch (Exception e)
			{
				if (e is BadChatRequestException)
				{
					Console.WriteLine("A request went wrong: " + e.Message);
					return BadRequest("Bad formatting on request");
				}
				Console.WriteLine("WARNING COVER LETTER GENERATED FAILED: " + e.Message);
				return StatusCode(500, "Something went wrong with generating the letter");
			}		
		}
	}
}
