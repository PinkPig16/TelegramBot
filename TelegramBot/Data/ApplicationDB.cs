using Microsoft.EntityFrameworkCore;

namespace TelegramBot.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options) 
        {

        }
    }
}
