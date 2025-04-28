using CareerKitBackend.Main.AIService.Exceptions;
using CareerKitBackend.Main.AIService.Service;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.CoverLetterService.DTO;
using CareerKitBackend.Main.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.CoverLetterService.Controller
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CoverLetterController(OpenAIService openAiService, TrackerService trackerService, Service.CoverLetterService coverLetterService) : ControllerBase
	{
		[HttpPost]
		[Route("generate/template")]
		public async Task<IActionResult> Generate([FromBody] FillCoverLetterRequest request)
		{
			// Check validity of request
			string ipAddress;
			try
			{
				ipAddress = RequestUtils.GetIPAddress(HttpContext);
				if (string.IsNullOrWhiteSpace(request.Template) || string.IsNullOrWhiteSpace(request.JobDescription))
					return BadRequest("Template and Job Description are required.");
				if (!trackerService.CanUseService(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress))
					return BadRequest("API exhausted, wait for daily reset.");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message); // Catches no IP requests
			}
			// Use AI Service
			try
			{
				string content = await openAiService.SendMessage
				(
					coverLetterService.GetTemplateSystemInstructions(),
					coverLetterService.GenerateTemplateMessage(request.Template, request.JobDescription)
				);
				trackerService.DecrementUsage(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress);
				return Ok(new CoverLetterResponse(content) { Result = content }); // TODO: Figure out a better way of doing this, this way is disgusting
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
		[HttpPost]
		[Route("generate/scratch")]
		public async Task<IActionResult> GenerateFromScratch([FromBody] ScratchCoverLetterRequest request)
		{
			string ipAddress;
			try
			{
				ipAddress = RequestUtils.GetIPAddress(HttpContext);
				if (string.IsNullOrWhiteSpace(request.JobDescription))
					return BadRequest("Template and Job Description are required.");
				if (!trackerService.CanUseService(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress))
					return BadRequest("API exhausted, wait for daily reset.");
			}
			catch (Exception e)
			{
				return BadRequest(e.Message);
			}
			try
			{
				string content = await openAiService.SendMessage
				(
					coverLetterService.GetScratchSystemInstructions(),
					coverLetterService.GenerateScratchMessage(request.JobDescription)
				);
				trackerService.DecrementUsage(ServiceEndpointsEnum.CoverLetterScratchService, ipAddress);
				return Ok(new CoverLetterResponse(content) { Result = content });
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
