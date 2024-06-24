using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using TelegramParse.Service;

namespace TelegramParse.Controllers
{
    [ApiController]
    [Route("api/message")]

    public class TelegramBotController : Controller
    {

        public TelegramBotController(TelegramBot telegramBot)
        {
            var _client = telegramBot.GetBot().Result;
        }
        

        [HttpPost]
        [Route("update")]
        public IActionResult update([FromBody]object update)
        {
            return Ok();
        }
    }
}
