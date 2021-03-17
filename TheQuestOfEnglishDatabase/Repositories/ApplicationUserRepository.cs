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
        private readonly SignInManager<IdentityUser> _signInManager;

        public ApplicationUserRepository(ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<IdentityUser> signInManager) : base(db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
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

        public async Task LogIn(ApplicationUser user)
        {
            await _signInManager.SignInAsync(user, isPersistent: false);
        }

        public async Task<IdentityResult> CreateAdminRole()
        {
            if (!await _roleManager.RoleExistsAsync(SD.AdminUser))
            {
                return await _roleManager.CreateAsync(new IdentityRole(SD.AdminUser));
            }
            else
            {
                return null;
            }
        }

        public async Task<IdentityResult> CreateUserRole()
        {
            if (!await _roleManager.RoleExistsAsync(SD.OrdinaryUser))
            {
                return await _roleManager.CreateAsync(new IdentityRole(SD.OrdinaryUser));
            }
            else
            {
                return null;
            }
        }
    }
}
