using Microsoft.EntityFrameworkCore;
using TelegramParse.Data;
using TelegramParse.Entity;
using TelegramParse.Interfaces;

namespace TelegramParse.Repository
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly ApplicationDB _context;
        public AppUserRepository(ApplicationDB context)
        {
            _context = context;
        }

        public async Task Add(AppUser user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(AppUser user)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }

        public  IEnumerable<AppUser> GetAllAsync()
        {
           throw new NotImplementedException();
        }

        public async Task<AppUser?> GetAsyncById(long id)
        {
           return await _context.appUsers.FindAsync(id);
        }
        public async Task UpdateAsync(AppUser user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
