using System.Collections.Generic;
using Telegram.Bot.Types;

namespace TelegramParse.Entity
{
    public class AppUser : User
    {
        public ICollection<Vacancies>? Vacancies { get; set; }
    }
}
