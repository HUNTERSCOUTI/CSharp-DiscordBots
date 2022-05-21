using Discord;
using Discord.Interactions;
using Discord.WebSocket;

namespace SimpleCsBot.Modules.Events;

public class InteractionCreated : IEvent
{
    private readonly DiscordSocketClient _client;
    private readonly IServiceProvider _serviceProvider;
    private readonly InteractionService _interactionService;

    public InteractionCreated(DiscordSocketClient client, IServiceProvider serviceProvider, InteractionService interactionService)
    {
        _client = client;
        _serviceProvider = serviceProvider;
        _interactionService = interactionService;
    }

    public async Task HandleEventAsync(SocketInteraction socketInteraction)
    {
        var ctx = CreateGeneric(_client, socketInteraction);
        await _interactionService.ExecuteCommandAsync(ctx, _serviceProvider);
    }
    
    private static IInteractionContext CreateGeneric(DiscordSocketClient client, SocketInteraction interaction) => interaction switch
    {
        SocketModal modal => new SocketInteractionContext<SocketModal>(client, modal),
        SocketUserCommand user => new SocketInteractionContext<SocketUserCommand>(client, user),
        SocketSlashCommand slash => new SocketInteractionContext<SocketSlashCommand>(client, slash),
        SocketMessageCommand message => new SocketInteractionContext<SocketMessageCommand>(client, message),
        SocketMessageComponent component => new SocketInteractionContext<SocketMessageComponent>(client, component),
        _ => throw new InvalidOperationException("This interaction type is unsupported! Please report this.")
    };
}