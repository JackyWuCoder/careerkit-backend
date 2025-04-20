using System.CodeDom.Compiler;
using CareerKitBackend.Main.CoverLetterService.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CareerKitBackend.Main.CoverLetterService.Controller
{
	[Route("api/v1/[controller]")]
	[ApiController]
	public class CoverLetterController : ControllerBase
	{
		[HttpPost]
		public IActionResult Generate([FromBody] FillCoverLetterRequest request)
		{
			if (string.IsNullOrWhiteSpace(request.Template) || string.IsNullOrWhiteSpace(request.JobDescription))
			{
				return BadRequest("Template and Job Description are required.");
			}

			return Ok(new { result = request.Template });
		}
	}
}
