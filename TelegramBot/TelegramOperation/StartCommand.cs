﻿using AutoMapper;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramParse.Entity;
using TelegramParse.Interfaces;

namespace TelegramParse.TelegramOperation
{
    public class StartCommand : ICommands
    {
        private readonly IAppUserRepository _userRepository;
        private readonly IMapper _mapper;

        public StartCommand(IAppUserRepository userRepository, IMapper mapper) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public string CommandName => "/start";

        public string HandleCommand(Update update)
        {
            User? user = update.Message?.From;
            var users =  _userRepository.GetAsyncById(user.Id);
            if (FindUser(user.Id) == null)
            {
                var appUser = _mapper.Map<AppUser>(user);
                _userRepository.Add(appUser);
                return "TEST";
            }
            return "Скажите на какие позиции необходимо присылать оповещения";
        }

        public async  Task<AppUser?> FindUser(long id)
        {
            return await _userRepository.GetAsyncById(id);
        }
    }
}
