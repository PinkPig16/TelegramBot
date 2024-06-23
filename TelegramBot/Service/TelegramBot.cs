using Telegram.Bot;
using TelegramParse.IService;

namespace TelegramParse.Service
{
    public class TelegramBot : ITelegramBot
    {
        private readonly IConfiguration _configuration;
        private readonly TelegramBotClient _client;
        public TelegramBot(TelegramBotClient telegramBotClient, IConfiguration configuration)
        {
            _configuration = configuration;
            _client = telegramBotClient;
        }
        public async Task<TelegramBotClient> GetBot()
        {
            await _client.SetWebhookAsync(_configuration["Uri"]);

            return _client;
        }
    }
}
