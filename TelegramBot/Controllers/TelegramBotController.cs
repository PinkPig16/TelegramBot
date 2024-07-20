using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramParse.Interfaces;
using TelegramParse.Parse;
using TelegramParse.Service;

namespace TelegramParse.Controllers
{
    [ApiController]
    [Route("api/message")]


    public class TelegramBotController : Controller
    {
        private readonly CommandsRegistry _commandsRegistry;
        private readonly ILoggerError _loggerError;
        private readonly IMessage _message;
        private readonly Run _run;

        public TelegramBotController(CommandsRegistry commandsRegistry, ILoggerError loggerError,
            IMessage message,Run run)
        {
            _commandsRegistry = commandsRegistry;
            _loggerError = loggerError;
            _message = message;
            _run = run;
            
        }
        [HttpPost]
        [Route("update")]
        public IActionResult update([FromBody] object update)
        {

            var upd = JsonConvert.DeserializeObject<Update>(update.ToString());
            if (upd != null)
            {
                var messageCommand = upd.Message.Text.Split(' ').First();
                var command = _commandsRegistry.GetCommandHandler(messageCommand);
                if (command == null)
                {
                    _loggerError.Log("Command not found");
                }
                else
                {
                    command.HandleCommand(upd);
                }
            }
            return Ok();
        }
        [HttpGet]
        [Route("Run")]
        public async Task<IActionResult> RunParse()
        {
            await _run.RunParse();
            return Ok();
        }

    }
}
