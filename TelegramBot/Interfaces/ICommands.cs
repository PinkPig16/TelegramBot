using Telegram.Bot.Types;

namespace TelegramParse.Interfaces
{
    public interface ICommands
    {
        string CommandName { get; }
        void HandleCommand(Update update);
    }
}
