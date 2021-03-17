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
        private readonly RoleManager<IdentityRole> _roleManager;
        public ApplicationUserRepository(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager) : base(db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ApplicationUser> GetUser(string id)
        {
            return await DbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
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
        public async Task<IdentityResult> AddUser(ApplicationUser user, string inputPassword)
        {
            await _userManager.AddToRoleAsync(user, SD.AdminUser);//Statycznie wszyscy są adminami teraz.
            return await _userManager.CreateAsync(user, inputPassword);
        }

        public async Task CreateAdminRole()
        {
            if (!await _roleManager.RoleExistsAsync(SD.AdminUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.AdminUser));
            }
        }

        public async Task CreateUserRole()
        {
            if (!await _roleManager.RoleExistsAsync(SD.OrdinaryUser))
            {
                await _roleManager.CreateAsync(new IdentityRole(SD.OrdinaryUser));
            }
        }
    }
}
