using System.Windows.Input;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Telegram.Bot.Types;
using TelegramParse.Entity;
using TelegramParse.Interfaces;

namespace TelegramParse.TelegramOperation
{
    public class AddCommand : ICommands
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IMapper _mapper;

        public string CommandName => "/add";

        public AddCommand(IAppUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public string HandleCommand(Update update)
        {
            User? user = update.Message?.From;
            String messageText = update.Message.Text;
            var wrods = ParseMessage(messageText);
            if (_userRepository.GetAsyncById(user.Id) != null)
            {
                var appUser = _mapper.Map<AppUser>(user);
                _userRepository.Add(appUser);
            }

            return "200";
        }
        public List<string> ParseMessage(string messageText)
        {
            return messageText.Split(' ').ToList();
            
        }
    }
}
