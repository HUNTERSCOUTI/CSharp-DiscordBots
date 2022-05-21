using Discord;
using Discord.Interactions;

namespace SimpleCsBot.Modules.Commands;

public class ModalExample : IModal
{
    public string Title => "My cool modal";
    
    [InputLabel("Modal title")]
    [ModalTextInput("modal_title", placeholder: "Give a title...")]
    public string? Name { get; set; }
    
    [InputLabel("What do u want to say?")]
    [ModalTextInput("modal_description", TextInputStyle.Paragraph, "...")]
    public string? Description { get; set; }
}