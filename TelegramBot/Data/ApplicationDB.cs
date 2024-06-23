using Microsoft.EntityFrameworkCore;

namespace TelegramParse.Data
{
    public class ApplicationDB : DbContext
    {
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {

        }
    }
}
