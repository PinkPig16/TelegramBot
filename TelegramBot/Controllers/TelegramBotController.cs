using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using TelegramParse.Service;

namespace TelegramParse.Controllers
{
    [ApiController]
    [Route("api/message")]

    public class TelegramBotController : Controller
    {
        private readonly  TelegramBotClient _client;

        public TelegramBotController(TelegramBot telegramBot)
        {
            _client = telegramBot.GetBot().Result;
        }
        

        [HttpPost]
        public IActionResult update()
        {
            return Ok();
        }
    }
}
