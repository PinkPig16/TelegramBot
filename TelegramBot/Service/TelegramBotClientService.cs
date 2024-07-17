using Microsoft.Extensions.Options;
using Telegram.Bot;

namespace TelegramParse.Service
{
    public class TelegramBotClientService : BackgroundService
    {
        private readonly TelegramConfigModel _config;
        public TelegramBotClient client { get; set; }
        public  TelegramBotClientService(IOptions<TelegramConfigModel> options)
        {
            _config = options.Value;
            client = new TelegramBotClient(_config.Token);

        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await client.SetWebhookAsync($"{_config.BaseUrL}api/message/update");

        }

        /*        public TelegramBotClient CreateClient()
       {
           if (!string.IsNullOrEmpty(_config.BaseUrL))
           {
               client.SetWebhookAsync($"{_config.BaseUrL}/api/message/update").Wait();
           }

           return client;
       }*/
    }
}
