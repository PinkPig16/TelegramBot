using Telegram.Bot.Types;

namespace TelegramParse.Interfaces
{
    public interface ICommands
    {
        string CommandName { get; }
        string HandleCommand(Update update);
    }
}
