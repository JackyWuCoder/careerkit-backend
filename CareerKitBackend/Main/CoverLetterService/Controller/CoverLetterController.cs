using CareerKitBackend.Main.CoverLetterService.DTO;
using CareerKitBackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.CoverLetterService.Controller
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CoverLetterController : ControllerBase
	{
		private readonly OpenAIService _openAiService;

		public CoverLetterController(OpenAIService openAiService)
		{
			_openAiService = openAiService;
		}

		[HttpPost]
		public async Task<IActionResult> Generate([FromBody] FillCoverLetterRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.Template) || string.IsNullOrWhiteSpace(request.JobDescription))
			{
				return BadRequest("Template and Job Description are required.");
			}

			string generated = await _openAiService.GenerateCoverLetterAsync(request.Template, request.JobDescription);

			return Ok(new { result = generated });
		}
	}
}
