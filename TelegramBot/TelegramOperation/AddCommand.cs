using System.Windows.Input;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Telegram.Bot.Types;
using TelegramParse.Data.Enum;
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
        public void HandleCommand(Update update)
        {
            User? user = update.Message?.From;
            String messageText = update.Message.Text;
            var Words = ParseMessage(messageText);
            if (_userRepository.GetAsyncById(user.Id) != null)
            {
                var appUser = _mapper.Map<AppUser>(user);
                _userRepository.Add(appUser);
            }
        }
        public List<string> ParseMessage(string messageText)
        {   var vacancies = new Vacancies();
            var words =  messageText.ToLower().Split(' ').ToList();
            
            if (ITPosition.)

            if (words.Count == 2)
            {
                vacancies.Name = words[1];
            } else if (words.Count == 3)
            {
                
            }
            
        }
    }
}
