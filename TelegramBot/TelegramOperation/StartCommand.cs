using AutoMapper;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramParse.Entity;
using TelegramParse.Interfaces;

namespace TelegramParse.TelegramOperation
{
    public class StartCommand : ICommands
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IMessage _message;

        public StartCommand(IAppUserRepository userRepository, IMapper mapper, IMessage message) 
        {
            _userRepository = userRepository;
            _message = message;
            
        }
        public string CommandName => "/start";

        public void HandleCommand(Update update)
        {
            User? user = update.Message?.From;
            
            var messageString = "Для подписки на рассылку вакансий используйте /add. \n Например: /add junior .net киев   /add C# remote";
            _message.Send(messageString, user.Id);
        }

        public async  Task<AppUser?> FindUser(long id)
        {
            return await _userRepository.GetAsyncById(id);
        }
    }
}
