using System.CodeDom.Compiler;
using System.Threading.Tasks;
using CareerKitBackend.Main.CoverLetterService.DTO;
using CareerKitBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.CoverLetterService.Controller
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CoverLetterController : ControllerBase
	{
		private readonly IConfiguration _config;

		public CoverLetterController(IConfiguration config)
		{
			_config = config;
		}

		[HttpPost]
		public async Task<IActionResult> Generate([FromBody] FillCoverLetterRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.Template) || string.IsNullOrWhiteSpace(request.JobDescription))
			{
				return BadRequest("Template and Job Description are required.");
			}

			var apiKey = _config["OpenAI:ApiKey"];
			var openaiService = new OpenAIService(apiKey);

			string generated = await openaiService.GenerateCoverLetterAsync(request.Template, request.JobDescription);

			return Ok(new { result = generated });
		}
	}
}
