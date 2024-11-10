using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Register GeminiClient and dependencies
builder.Services.AddGemini(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Write prompts to /generate-content to try out the Gemini AI model!");

// Define an endpoint that uses GeminiClient
app.MapGet("/generate-content", async (string prompt, GeminiClient geminiClient, CancellationToken cancellationToken) =>
{
    Trace.WriteLine("Received prompt: " + prompt);

    // Call the GenerateContentAsync method
    try
    {
        var content = await geminiClient.GenerateContentAsync(prompt, cancellationToken);
        return Results.Ok(content);
    }
    catch (Exception ex)
    {
        Trace.WriteLine($"Error generating content: {ex.Message}");
        return Results.Problem("Failed to generate content.");
    }
});

app.Run();
