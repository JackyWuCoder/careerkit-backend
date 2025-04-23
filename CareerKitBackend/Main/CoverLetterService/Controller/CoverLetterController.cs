using CareerKitBackend.Main.CoverLetterService.DTO;
using CareerKitBackend.Main.AIService.Service;
using Microsoft.AspNetCore.Mvc;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.CoverLetterService.Service;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.AIService.Exceptions;

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
			// TODO: Implement getting IP address from requester
			if (!trackerService.CanUseService(ServiceEndpointsEnum.CoverLetterAutofillService, "fillerIPHere"))
			{
				return BadRequest("API exhausted, wait for daily reset.");
			}
			try
			{
				string content = await openAiService.SendMessage
				(
					coverLetterService.GetSystemInstructions(), 
					coverLetterService.GenerateUserMessage(request.Template, request.JobDescription)
				);
				// TODO: Implement getting IP address from requester
				trackerService.DecrementUsage(ServiceEndpointsEnum.CoverLetterAutofillService, "fillerIPHere");
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
