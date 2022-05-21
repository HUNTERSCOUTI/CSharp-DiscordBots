using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

class Program
{
    static void Main() => new Program().RunBotAsync().GetAwaiter().GetResult();
    
    
    private DiscordSocketClient _client;
    private CommandService _commands;
    private IServiceProvider _services;

    public async Task RunBotAsync()
    {
        _client = new DiscordSocketClient();
        _commands = new CommandService();
        _services = new ServiceCollection()
            .AddSingleton(_client)
            .AddSingleton(_commands)
            .BuildServiceProvider();

        string token = "OTc3NjY1OTM3NzU3MDYxMTgz.GVVcdQ.xcdfqnRqc1ZHLr23ifoPLU78rz85t_4f7CooIE";

        _client.Log += _client_Log;

        await RegisterCommandsAsyc();

        await _client.LoginAsync(TokenType.Bot, token);

        await _client.StartAsync();

        await Task.Delay(-1);
    }

    private Task _client_Log(LogMessage arg)
    {
        Console.WriteLine(arg);
        return Task.CompletedTask;
    }

    public async Task RegisterCommandsAsyc()
    {
        _client.MessageReceived += HandleCommandAsync;
        await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
    }

    private async Task HandleCommandAsync(SocketMessage arg)
    {
        var message = arg as SocketUserMessage;
        var context = new SocketCommandContext(_client, message);
        if (message.Author.IsBot) return;

        int argPos = 0;
        if (message.HasStringPrefix("/", ref argPos))
        {
            var result = await _commands.ExecuteAsync(context, argPos, _services);
            if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
        }
    }
}