using Microsoft.EntityFrameworkCore;
using TelegramParse.Entity;

namespace TelegramParse.Data
{
    public class ApplicationDB : DbContext
    {
        public DbSet<AppUser> appUsers { get; set; } = null!;
        public ApplicationDB(DbContextOptions<ApplicationDB> options) : base(options)
        {

        }
    }
}
