using Discord;
using Discord.Commands;
using Discord.Interactions;

namespace TheBoisBot.Modules;

public class Commands : ModuleBase<SocketCommandContext>
{
    [SlashCommand("Ping", "Play a bit of ping pong")]
    public async Task Ping()
    {
        await ReplyAsync("Pong");
    }
}
