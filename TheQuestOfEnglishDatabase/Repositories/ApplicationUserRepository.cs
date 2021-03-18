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

        public async Task<SignInResult> LogIn(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username,
            password, false, lockoutOnFailure: true);
        }
        public async Task<ApplicationUser> GetUser(string username)
        {
            return await DbSet.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }
        public async Task<bool> DeleteUser(string id)
        {

            //var allEntities = DbSet.Select(x => x);
            //foreach (var item in allEntities)
            //{
            //    DbSet.Remove(item);
            //}
            //await SaveChanges();
            var foundentity = await dbset.firstordefaultasync(x => x.id == id);
            if (foundentity != null)
            {
                dbset.remove(foundentity);
                return await savechanges();
            }
            return false;
        }
    }
}
