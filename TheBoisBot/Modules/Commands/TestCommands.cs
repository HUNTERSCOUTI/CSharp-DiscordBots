using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using SimpleCsBot.Utils;

namespace SimpleCsBot.Modules.Commands;

public class TestCommands : BotInteraction<SocketSlashCommand>
{
    [SlashCommand("slash", "slash command")]
    public async Task HandleSlash()
    {
        await RespondAsync("I am a slash command");
    }

    [SlashCommand("button", "button command")]
    public async Task HandleButton()
    {
        var btn = new ButtonBuilder
        {
            Label = "Click me",
            CustomId = "click_button",
            Style = ButtonStyle.Primary,
        };

        await RespondAsync("Cool button", components: new ComponentBuilder().WithButton(btn).Build());
    }

    [SlashCommand("menu", "menu command")]
    public async Task HandleMenu()
    {
        var selectMenu = new SelectMenuBuilder
        {
            CustomId = "menu_selection",
            Placeholder = "Select an option",
            MinValues = 1,
            MaxValues = 3,
        };

        selectMenu.AddOption("Hey", "hey", "This is an cool description");
        selectMenu.AddOption("Hoi", "hoi", "This is an cool description");
        selectMenu.AddOption("Hallo", "hallo", "This is an cool description");
        selectMenu.AddOption("Haiii", "haiii", "This is an cool description");

        await RespondAsync("Select an option", components: new ComponentBuilder().WithSelectMenu(selectMenu).Build());
    }

    [SlashCommand("modal", "modal command")]
    public async Task HandleModal()
    {
        await RespondWithModalAsync<ModalExample>("modal_example");
    }
}