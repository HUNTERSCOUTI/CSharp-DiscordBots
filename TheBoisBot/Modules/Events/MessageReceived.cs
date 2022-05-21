using System;
using System.Threading.Tasks;
using Discord.Commands;
using Discord.WebSocket;

namespace SimpleCsBot.Modules.Events;


public class MessageReceived : IEvent
{
    private readonly DiscordSocketClient _client;
    private readonly CommandService _commandService;
    private readonly IServiceProvider _serviceProvider;

    public MessageReceived(DiscordSocketClient client, CommandService commandService, IServiceProvider serviceProvider)
    {
        _client = client;
        _commandService = commandService;
        _serviceProvider = serviceProvider;
    }

    public async Task HandleEventAsync(SocketMessage socketMessage)
    {
        if (socketMessage.Author.IsBot) return;
        if (!(socketMessage is SocketUserMessage message)) return;

        var argumentPosition = 0;
        var prefix = '/';

        if (message.HasCharPrefix(prefix, ref argumentPosition))
        {
            var context = new SocketCommandContext(_client, message);
            await _commandService.ExecuteAsync(context, argumentPosition, _serviceProvider);
        }

        await Task.CompletedTask;
    }
}