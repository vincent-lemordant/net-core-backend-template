using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using OllamaSharp;
using OllamaSharp.Models.Chat;

namespace Infrastructure.IA;

public class IAService
{
    private OllamaApiClient _ollamaApiClient { get; set; }

    private Chat chat { get; set; }
    private string response { get; set; }
    private ILogger<IAService> _logger { get; set; }

    public IAService(IConfiguration configuration, ILogger<IAService> logger)
    {
        var uri = new Uri(configuration.GetRequiredSection("IAEndpoint").Value!);
        _ollamaApiClient = new OllamaApiClient(uri, "llama3");
        chat = _ollamaApiClient.Chat(stream => response += stream?.Message?.Content ?? "");
        response = string.Empty;
        _logger = logger;
    }

    public async Task<string> Chat(string prompt)
    {
        response = string.Empty;
        await chat.SendAs(ChatRole.User, prompt);
        return response;
    }

    public async Task LoadModel()
    {
        _logger.LogDebug("Start model loading.");
        var defaultPrompt = @"---
        You are a blog author and currently working for an important marketing company
        in Canada that is selling construction site stuff.
        ---";
        await chat.SendAs(ChatRole.System, defaultPrompt);
        response = string.Empty;
        _logger.LogDebug("Model loaded.");
    }
}