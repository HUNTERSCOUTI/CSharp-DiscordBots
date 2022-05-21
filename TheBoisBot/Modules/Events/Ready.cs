using Discord.Interactions;
using Discord.WebSocket;

namespace SimpleCsBot.Modules.Events;

public class Ready : IEvent
{
    private readonly DiscordSocketClient _client;
    private readonly InteractionService _interactionService;

    public Ready(DiscordSocketClient client, InteractionService interactionService)
    {
        _client = client;
        _interactionService = interactionService;
    }

    public async Task HandleEventAsync()
    {
        Console.WriteLine($"{_client.CurrentUser.Username} is online!");
        Console.WriteLine($"{_client.CurrentUser.Username} was ready in {(DateTime.Now - DiscordBot.BotStarted).Milliseconds}ms");
        
        RegisterCommands();

        await Task.CompletedTask;
    }

    private async void RegisterCommands()
    {
        #if DEBUG
        await _interactionService.RegisterCommandsToGuildAsync(800645257552986123);
        #else
        await _interactionService.RegisterCommandsGloballyAsync();
        #endif
    }
}