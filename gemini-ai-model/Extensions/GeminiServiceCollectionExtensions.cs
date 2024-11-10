using Microsoft.Extensions.Options;

public static class GeminiServiceCollectionExtensions
{
    public static void AddGemini(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<GeminiOptions>(configuration.GetSection("Gemini"));
        services.AddTransient<GeminiDelegatingHandler>();

        services.AddHttpClient<GeminiClient>(
            (serviceProvider, httpClient) =>
            {
                var geminiOptions = serviceProvider.GetRequiredService<IOptions<GeminiOptions>>().Value;
                httpClient.BaseAddress = new Uri(geminiOptions.Url);
            })
            .AddHttpMessageHandler<GeminiDelegatingHandler>();
    }
}
