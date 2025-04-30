using CareerKitBackend.Main.AIService.Exceptions;
using CareerKitBackend.Main.AIService.Service;
using CareerKitBackend.Main.APITrackerService.Model;
using CareerKitBackend.Main.APITrackerService.Service;
using CareerKitBackend.Main.InterviewService.DTO;
using CareerKitBackend.Main.Utils;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.InterviewService.Controller
{
	[Route("api/v1/interview")]
	[ApiController]
	public class InterviewController(OpenAIService openAiService, TrackerService trackerService, Service.InterviewService interviewService) : ControllerBase
	{
		[HttpPost]
		[Route("generate/questions")]
		public async Task<IActionResult> GenerateQuestions([FromBody] InterviewQuestionsRequest request)
		{
			try
			{
				string ipAddress = RequestUtils.GetIPAddress(HttpContext);
				if (!trackerService.CanUseService(ServiceEndpointsEnum.InterviewQuestionsService, ipAddress))
					return BadRequest("API exhausted, wait for daily reset");

				string content = await openAiService.SendMessage
				(
					interviewService.GetGenerateQuestionsSystemInstructions(),
					interviewService.GenerateQuestionsMessage(request.JobDescription)
				);
				trackerService.DecrementUsage(ServiceEndpointsEnum.InterviewQuestionsService, ipAddress);
				return Ok(new InterviewQuestionsResponse(content));
			}
			catch (Exception e)
			{
				return GetActionFromException(e);
			}
		}
		private IActionResult GetActionFromException(Exception exception) // TODO: This is just from the cover letter controller, find a better way to handle this
		{
			if (exception is EmptyResponseException) return StatusCode(500, "Something went wrong with generating the letter");
			else return BadRequest(exception.Message);
		}
	}
}
