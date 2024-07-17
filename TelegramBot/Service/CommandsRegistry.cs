using TelegramParse.Interfaces;
namespace TelegramParse.Service
{
    public class CommandsRegistry
    {
        private readonly Dictionary<string, ICommands> _commandHandlers = new();
        

        public CommandsRegistry(IEnumerable<ICommands> commandHandlers)
        {
            foreach (var handler in commandHandlers)
            {
                _commandHandlers[handler.CommandName] = handler;
            }
        }

        public ICommands? GetCommandHandler(string commandName)
        {
            _commandHandlers.TryGetValue(commandName, out var handler);
            return handler;
        }
    }
}
