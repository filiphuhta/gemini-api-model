var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGemini(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Write prompts to /generate-content to try out the Gemini AI model!");
app.MapControllers();

app.Run();
