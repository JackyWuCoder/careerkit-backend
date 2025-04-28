using CareerKitBackend.Main.AIService.Exceptions;
using CareerKitBackend.Main.AIService.Service;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.CoverLetterService.DTO;
using CareerKitBackend.Main.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.CoverLetterService.Controller
{
	[Route("api/v1/coverLetter")]
	[ApiController]
	public class CoverLetterController(OpenAIService openAiService, TrackerService trackerService, Service.CoverLetterService coverLetterService) : ControllerBase
	{
		[HttpPost]
		[Route("generate/template")]
		public async Task<IActionResult> Generate([FromBody] FillCoverLetterRequest request)
		{
			try
			{
				string ipAddress = RequestUtils.GetIPAddress(HttpContext);
				RequestUtils.ValidateRequestFields(request.Template, request.JobDescription);
				if (!trackerService.CanUseService(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress))
					return BadRequest("API exhausted, wait for daily reset");

				string content = await openAiService.SendMessage
				(
					coverLetterService.GetTemplateSystemInstructions(),
					coverLetterService.GenerateTemplateMessage(request.Template, request.JobDescription)
				);
				trackerService.DecrementUsage(ServiceEndpointsEnum.CoverLetterAutofillService, ipAddress);
				return Ok(new CoverLetterResponse(content) { Result = content }); // TODO: Figure out better way of doing this, this way is disgusting
			}
			catch (Exception e)
			{
				return GetActionFromException(e);
			}
		}

		[HttpPost]
		[Route("generate/scratch")]
		public async Task<IActionResult> GenerateFromScratch([FromBody] ScratchCoverLetterRequest request)
		{
			try
			{
				string ipAddress = RequestUtils.GetIPAddress(HttpContext);
				if (!trackerService.CanUseService(ServiceEndpointsEnum.CoverLetterScratchService, ipAddress))
					return BadRequest("API exhaused, wait for daily reset");

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
				return GetActionFromException(e);
			}
		}

		private IActionResult GetActionFromException(Exception exception)
		{
			if (exception is EmptyResponseException) return StatusCode(500, "Something went wrong with generating the letter");
			else return BadRequest(exception.Message);
		}
	}
}
