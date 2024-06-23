using Telegram.Bot;

namespace TelegramParse.IService
{
    interface ITelegramBot
    {
        Task<TelegramBotClient> GetBot();
    }
}
