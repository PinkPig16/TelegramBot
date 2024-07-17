using AutoMapper;
using Telegram.Bot.Types;

namespace TelegramParse.Entity.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<User, AppUser>();
        }
    }
}
