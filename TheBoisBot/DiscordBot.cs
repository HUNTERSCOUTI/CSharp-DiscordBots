using Discord;
using Discord.WebSocket;
using SimpleCsBot.Modules.Events;

namespace SimpleCsBot;

public class DiscordBot
{
    private readonly DiscordSocketClient _client;

    private readonly Ready _ready;
    private readonly MessageReceived _messageReceived;
    private readonly InteractionCreated _interactionCreated;

    public static DateTime BotStarted;

    public DiscordBot(DiscordSocketClient client, Ready ready, MessageReceived messageReceived, InteractionCreated interactionCreated)
    {
        _client = client;
        _ready = ready;
        _messageReceived = messageReceived;
        _interactionCreated = interactionCreated;
    }

    public async Task RunAsync()
    {
        await _client.LoginAsync(TokenType.Bot, "OTc3NjY1OTM3NzU3MDYxMTgz.GS3J-G.TECP2TJ77acC-KJ5WtDBxvuP58u0mxnKGBqofg");
        await _client.SetGameAsync("Valorant");
        await _client.SetStatusAsync(UserStatus.Idle);
        await _client.StartAsync();

        _client.Ready += _ready.HandleEventAsync;
        _client.InteractionCreated += _interactionCreated.HandleEventAsync;
        _client.MessageReceived += _messageReceived.HandleEventAsync;

        await Task.Delay(Timeout.Infinite);
    }
    

}