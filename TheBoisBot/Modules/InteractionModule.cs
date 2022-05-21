using Discord;
using Discord.Commands;
using Discord.Interactions;

namespace TheBoisBot.Menus;

public class InteractionModule : InteractionModuleBase<SocketInteractionContext>
{
    [SlashCommand("menu", "Demonstrate menu")]
    public async Task HandleMenuCommand()
    {
        var menu = new SelectMenuBuilder()
        {
            CustomId = "menu",
            Placeholder = "Sample Menu"
        };
        menu.AddOption("Option A", "opt-a", "Option B is lying!");
        menu.AddOption("Option B", "opt-b", "Option A is telling the truth!");

        var component = new ComponentBuilder();
        component.WithSelectMenu(menu);

        await RespondAsync("testing", components: component.Build());
    }

    [ComponentInteraction("menu")]
    public async Task HandleMenuSelection(string[] inputs)
    {
        await RespondAsync(inputs[0]);
    }

    [ModalInteraction("demo_modal1")]
    public async Task HandleModalInput(DemoModal modal)
    {
        string input = modal.Greeting;
        await RespondAsync(input);
    }
}

public class DemoModal : IModal
{
    public string Title => "Demo Model";
    [InputLabel("Send a greeting!")]
    [ModalTextInput("greeting_input", TextInputStyle.Short, placeholder: "Be nice...", maxLength: 100)]
    public string Greeting { get; set; }
}