using Discord.Interactions;
using Discord.WebSocket;
using SimpleCsBot.Utils;

namespace SimpleCsBot.Modules.Commands;

public class ModalHandler : BotInteraction<SocketModal>
{
    [ModalInteraction("modal_example")]
    public async Task HandleModal(ModalExample modal)
    {
        await RespondAsync($"{modal.Name} - {modal.Description}");
    }
}