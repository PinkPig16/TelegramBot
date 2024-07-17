using Telegram.Bot.Types;
using TelegramParse.Entity;

namespace TelegramParse.Interfaces
{
    public interface IAppUserRepository
    {
        Task<AppUser?> GetAsyncById(long id);
        IEnumerable<AppUser> GetAllAsync();
        Task Add(AppUser user);
        Task UpdateAsync(AppUser user);
        Task DeleteAsync(AppUser user);
    }
}
