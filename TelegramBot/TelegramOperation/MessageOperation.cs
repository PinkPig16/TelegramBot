using Telegram.Bot;
using TelegramParse.Interfaces;
using TelegramParse.Service;

namespace TelegramParse.TelegramOperation
{
    public class MessageOperation : IMessage        
    {
        private readonly TelegramBotClientService telegram;
        public MessageOperation(TelegramBotClientService bot)
        {
            telegram = bot;
        }

        public async Task Send(string text, long id)
        {
            await telegram.client.SendTextMessageAsync(id, text);
        }
    }
}
