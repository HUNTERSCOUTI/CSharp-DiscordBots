using System.Reflection;
using Discord.Commands;
using Discord.Interactions;

namespace SimpleCsBot.Core.InteractionHandling;

public class InteractionHandler
{
    private readonly CommandService _commandService;
    private readonly IServiceProvider _serviceProvider;
    private readonly InteractionService _interactionService;

    public InteractionHandler(CommandService commandService, IServiceProvider serviceProvider, InteractionService interactionService)
    {
        _commandService = commandService;
        _serviceProvider = serviceProvider;
        _interactionService = interactionService;
    }

    public async Task InitializeAsync()
    {
        await _interactionService.AddModulesAsync(Assembly.GetExecutingAssembly(), _serviceProvider);
        await _commandService.AddModulesAsync(Assembly.GetExecutingAssembly(), _serviceProvider);
    }
}