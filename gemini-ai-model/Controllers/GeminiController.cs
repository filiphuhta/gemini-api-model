using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace gemini_ai_model.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GeminiController : ControllerBase
    {
        private readonly GeminiClient _geminiClient;

        public GeminiController(GeminiClient geminiClient)
        {
            _geminiClient = geminiClient;
        }

        [HttpGet("generate-content")]
        public async Task<IActionResult> GenerateContent(string prompt, CancellationToken cancellationToken)
        {
            Trace.WriteLine("Received prompt: " + prompt);
            try
            {
                var content = await _geminiClient.GenerateContentAsync(prompt, cancellationToken);
                return Ok(content);
            }
            catch (Exception ex)
            {
                Trace.WriteLine($"Error generating content: {ex.Message}");
                return Problem("Failed to generate content.");
            }
        }
    }
}