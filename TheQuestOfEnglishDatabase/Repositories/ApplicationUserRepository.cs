using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_quest_of_English.Utilities;
using TheEnglishQuestDatabase.Entities;
using TheQuestOfEnglishDatabase;

namespace TheEnglishQuestDatabase
{
    public class ApplicationUserRepository : BaseRepository<ApplicationUser>, IApplicationUserRepository
    {
        protected override DbSet<ApplicationUser> DbSet => _db.ApplicationUser;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ApplicationUserRepository(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager) : base(db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUser(ApplicationUser user)
        {
            return await _userManager.CreateAsync(user);
        }

        public async Task LogIn(ApplicationUser user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }
        public async Task<ApplicationUser> GetUser(string username)
        {
            return await DbSet.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteUser(string id)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (foundEntity != null)
            {
                DbSet.Remove(foundEntity);
                return await SaveChanges();
            }
            return false;
        }
    }
}
