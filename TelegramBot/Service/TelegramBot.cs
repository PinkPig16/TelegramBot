using Telegram.Bot;
using TelegramParse.IService;

namespace TelegramParse.Service
{
    public class TelegramBot : ITelegramBot
    {
        private readonly IConfiguration _configuration;
        public TelegramBot(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<TelegramBotClient> GetBot()
        {
            var _client = new TelegramBotClient(_configuration["Token"]);
            await _client.SetWebhookAsync($"{_configuration["BaseUrl"]}api/message/update");

            return _client;
        }
    }
}
